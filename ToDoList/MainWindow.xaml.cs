﻿using System;
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


namespace ToDoList
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CodeFirst.Appcontext db;
        public MainWindow()
        {
            InitializeComponent(); 
            GetThisDate();
            db = new CodeFirst.Appcontext();
            LoadList();
            this.DataContext =  new CodeFirst.AppViewModel();
        }

        private void GetThisDate()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { ThisMyDayDate.Text = DateTime.Now.ToString(); };
            timer.Start();
        }
        public void LoadList()
        {
            lbList.ItemsSource = (from x in db.Lists
                                  select new
                                  {
                                      CatList = x.NameLists
                                  }).ToList();
            
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
