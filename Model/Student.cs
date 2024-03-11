using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Model
{
    /// <summary>
    /// Класс студента
    /// </summary>
    public class Student : INotifyPropertyChanged, IDomainObject
    {
        /// <summary>
        /// Id студента
        /// </summary>
        private int id;
        public int Id
        {
            get

            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        /// <summary>
        /// Имя студента
        /// </summary>
        private string name;
        public string Name
        {
            get

            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Неверное значение");
                }
                name = value;
                OnPropertyChanged("Name");
            }
        }
        /// <summary>
        /// Специальность студента
        /// </summary>
        private string speciality;
        public string Speciality
        {
            get

            {
                return speciality;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Неверное значение");
                }
                speciality = value;
                OnPropertyChanged("Speciality");
            }
        }
        /// <summary>
        /// Группа студента
        /// </summary>
        private string group;
        public string Group
        {
            get

            {
                return group;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Неверное значение");
                }
                group = value;
                OnPropertyChanged("Group");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
