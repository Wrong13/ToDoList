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
using ToDoList.CodeFirst;

namespace ToDoList.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddListWindow.xaml
    /// </summary>
    public partial class AddListWindow : Window
    {
        public Lists Lists { get; private set; }
        public AddListWindow(Lists lists)
        {
            InitializeComponent();
            Lists = lists;
            this.DataContext = Lists;
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
