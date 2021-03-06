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

namespace CodeFirstLib
{
    public class AppViewModel : INotifyPropertyChanged
    {
        Appcontext db;
        private Lists selectedList;
        IEnumerable<Lists> lists;

        RelayCommand addCommand;

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

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? 
                    (addCommand = new RelayCommand((o) =>
                    {
                        AddListWindow addListWindow = new AddListWindow(new Lists());
                    }
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
