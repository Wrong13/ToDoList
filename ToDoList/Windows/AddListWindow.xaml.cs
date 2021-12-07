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
using CodeFirstLib;

namespace ToDoList.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddListWindow.xaml
    /// </summary>
    public partial class AddListWindow : Window
    {
        Appcontext db;
        public AddListWindow()
        {
            InitializeComponent();
            db = new Appcontext();
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            CodeFirstLib.Lists list = new Lists();
            list.NameLists = ListAddBox.Text;
            db.Lists.Add(list);
            db.SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.LoadList();
            mainWindow.Show();
            this.Close();
        }
    }
}
