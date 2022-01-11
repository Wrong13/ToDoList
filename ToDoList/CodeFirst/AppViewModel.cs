using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity;
using ToDoList.Windows;

namespace ToDoList.CodeFirst
{
    public class AppViewModel : INotifyPropertyChanged
    {
        Appcontext db;
        
        IEnumerable<Lists> lists;

        RelayCommand addlist;
        RelayCommand dellist;
        RelayCommand editlist;

        public IEnumerable<Lists> List
        {
            get { return lists; }
            set { lists = value; OnPropertyChanged("List"); }
        }
        public AppViewModel()
        {
            db = new Appcontext();
            db.Lists.Load();
            List = db.Lists.Local.ToBindingList();
        }

        public RelayCommand AddList
        {
            get
            {
                return addlist ??
                    (addlist = new RelayCommand((o) =>
                    {
                        AddListWindow addListWindow = new AddListWindow(new Lists());
                        if (addListWindow.ShowDialog() == true)
                        {
                            Lists lists = addListWindow.Lists;
                            db.Lists.Add(lists);
                            db.SaveChanges();
                        }
                    }));
            }
        }

        public RelayCommand DelList
        {
            get
            {
                return dellist ??
                    (dellist = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null)
                            return;

                        Lists list = selectedItem as Lists;
                        db.Lists.Remove(list);
                        db.SaveChanges();
                    })) ;
            }
        }

        public RelayCommand EditList
        {
            get
            {
                return editlist ??
                    (editlist = new RelayCommand((selectedItem) =>
                    {
                        if (selectedItem == null) return;
                        Lists lists = selectedItem as Lists;
                        Lists list = new Lists()
                        {
                            ID = lists.ID,
                            NameLists = lists.NameLists,
                            Description = lists.Description,
                            Img = lists.Img
                        };
                        Windows.DoWindow addList = new DoWindow(list);
                        if (addList.ShowDialog() == true)
                        {
                            lists = db.Lists.Find(addList.Lists.ID);
                            if (lists != null)
                            {
                                lists.NameLists = addList.Lists.NameLists;
                                lists.Description = addList.Lists.Description;
                                db.Entry(lists).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                        }
                    }));
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
