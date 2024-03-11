using BLogic;
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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для Hystogramm.xaml
    /// </summary>
    public partial class Hystogramm : Window
    {
        /// <summary>
        /// Действия которые происходят при загрузке окна Гистогрыммы.
        /// </summary>
        /// <param name="logic">Объект класса логики</param>
        public Hystogramm(Logic logic)
        {
            InitializeComponent();
            DataContext = logic;
        }
    }
}
