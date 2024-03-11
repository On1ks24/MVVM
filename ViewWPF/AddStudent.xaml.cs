﻿using BLogic;
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
using System.Windows.Shapes;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        /// <summary>
        /// Действия, которые происходят при загрузке формы
        /// </summary>
        /// <param name="logic">Объект класса логики</param>
        public AddStudent(Logic logic)
        {
            InitializeComponent();
            DataContext = logic;
        }
        /// <summary>
        /// Действия, которые происходят при нажатии на кнопку "Добавить"
        /// </summary>
        /// <param name="sender">Объект, содержащий ссылку на объект, вызвавший событие</param>
        /// <param name="e">Контейнер, содержащий данные о событии</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
