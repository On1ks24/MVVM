using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLogic;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Объект класса логики
        /// </summary>
        private Logic _logic = new Logic();
        /// <summary>
        /// Действия, которые происходят при загрузке окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _logic;
        }
        /// <summary>
        /// Дейсвтия, которые происходят при нажатии на кнопку "Добавить студента"
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddStudent(_logic);
            window.ShowDialog();
            window.TextBox1.Clear();
            window.TextBox2.Clear();
            window.TextBox3.Clear();
        }
        /// <summary>
        /// Дейсвтия, которые происходят при нажатии на кнопку "Показать Гистограмму"
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window1 = new Hystogramm(_logic);
            window1.Show();
        }
    }
}
