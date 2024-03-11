using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Model;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using DataAccessLayer;

namespace BLogic
{   
    /// <summary>
    /// Этот класс отвечает за логику работы со студентами и их списком.
    /// </summary>
    public class Logic:INotifyPropertyChanged
    {
        //private IRepository<Student> studentRepository = new EntityRepository<Student>();
        private IRepository<Student> studentRepository = new DapperRepository<Student>();

        /// <summary>
        /// Констуктор класса логики.
        /// </summary>
        public Logic()
        {
            Students = (ObservableCollection<Student>)studentRepository.GetAll();
            id = 1;
            CommandAdd = new RelayCommand(AddStudent);
            CommandDelete = new RelayCommand(DeleteStudent);
            NewStudent = new Student();
        }
        /// <summary>
        /// Команда для добавления студента, используемая в WPF.
        /// </summary>
        public RelayCommand CommandAdd { get; set; }
        /// <summary>
        /// Команда для удаления студента, используемая в WPF.
        /// </summary>
        public RelayCommand CommandDelete { get; set; }
        /// <summary>
        /// Переменная для автоматического присваивания Id студентам.
        /// </summary>
        int id;
        private Student newstudent;
        /// <summary>
        /// Объект класса студента, который используется для добавления студентов.
        /// </summary>
        public Student NewStudent
        {
            get
            {
                return newstudent;
            }
            set
            {
                newstudent = value;
                OnPropertyChanged("NewStudent");
            }
        }
        private Student selectedstudent { get; set; }
        /// <summary>
        /// Объект класса студента, который обозначает выбранного студента и используется для удаления студента.
        /// </summary>
        public Student SelectedStudent
        {
            get
            {
                return selectedstudent;
            }
            set
            {
                selectedstudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }
        /// <summary>
        /// Этот лист хранит в себе всех студентов.
        /// </summary>
        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }
        /// <summary>
        /// Эта функция добавляет студента в лист студентов.
        /// </summary>
        public void AddStudent()
        {
            //CheckId();
            Students.Add(new Student
            {
                Name=NewStudent.Name,
                Speciality=NewStudent.Speciality,
                Group=NewStudent.Group,
            });
            studentRepository.Add(NewStudent);
            studentRepository.Save();
        }
        /// <summary>
        /// Этот метод не даёт присоить уже существующий айди другому студенту.
        /// </summary>
        public void CheckId()
        {
            List<int> ids = new List<int>();
            foreach(Student student in students)
            {
                ids.Add(student.Id);
            }
            id = ids.Max() + 1;
        }
        /// <summary>
        /// Создает студента
        /// </summary>
        /// <param name="name">имя студента</param>
        /// <param name="speciality">специальность студента</param>
        /// <param name="group">Группа студента</param>
        public void CreateStudent(string name,string speciality,string group)
        {
            //CheckId();
            NewStudent.Id = id;
            NewStudent.Name= name;
            NewStudent.Speciality = speciality;
            NewStudent.Group = group;
            id++;
        }
        /// <summary>
        /// Функция, которая выбирает определенного студента
        /// </summary>
        /// <param name="id">айди студента</param>
        public void SelectStudent(int id)
        {
            foreach(Student student in students)
            {
                if(student.Id == id)
                {
                    selectedstudent=student;
                }
            }
        }
        /// <summary>
        /// Эта функция отвечает за удаление студента из списка студентов.
        /// </summary>
        public void DeleteStudent()
        {
            foreach(Student student in Students)
            {
                if (student == selectedstudent)
                {
                    Students.Remove(student);
                    break;
                }    
            }
            studentRepository.Delete(id);
            studentRepository.Save();
        }
        /// <summary>
        /// Эта функция отвечает за создание списка всех специальностей.Необходима для реализации гистограммы.
        /// </summary>
        /// <returns>Лист всех спецальностей, на которые зачислены студенты</returns>
        public List<string> Specialities()
        {
            List<string> specialities = new List<string>();
            foreach (Student s in Students)
            {
                specialities.Add(s.Speciality);
            }
            return specialities;
        }
        private Dictionary<string,double> dictionaryCountSpecialities { get; set; }
        /// <summary>
        /// Словарь со всеми специальностями и количеством студентов,зачисленных на эту специальность.
        /// </summary>
        public Dictionary<string, double> DictionaryCountSpecialities
        {
            get
            {
                List<string> special = Specialities();
                Dictionary<string, double> result = special.GroupBy(x => x).ToDictionary(g => g.Key, g => Convert.ToDouble(g.Count()));
                return result;
            }
            set
            {
                dictionaryCountSpecialities = value;
                OnPropertyChanged(nameof(DictionaryCountSpecialities));
            }
        }
        /// <summary>
        /// Эта функция отвечает за реализацию вывода всех студентов.
        /// </summary>
        /// <returns>Лист с именами, специальностями и группами студентов</returns>
        public List <string> ViewStudents()
        {
            List<string> s = new List<string>();
            foreach(Student student in Students)
            {
                s.Add(student.Id.ToString());
                s.Add(student.Name);
                s.Add(student.Speciality);
                s.Add(student.Group);
            }
            return s;

        }
        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged
        /// </summary>
        /// <param name="prop">строка(?)</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
