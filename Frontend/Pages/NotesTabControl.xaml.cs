using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using CommandQuery.DatabaseContext;
using Entities.Entities;
using Entities.Extensions;

namespace Frontend.Pages
{
    /// <summary>
    /// Interaction logic for NotesTabControl.xaml
    /// </summary>
    public partial class NotesTabControl : UserControl
    {
        private readonly ObservableCollection<Note> _notes;
        public NotesTabControl()
        {
            InitializeComponent();
            var dbCommunicator = new DatabaseCommunicator();
            _notes = new ObservableCollection<Note>(dbCommunicator.GetAll<Note>());
            NotesListBox.ItemsSource = _notes;
            DataContext = this;
        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            var dbCommunicator = new DatabaseCommunicator();
            var note = new Note() { DateEdited = DateTime.Now.ToMbmString(), Message = TextBox.Text };
            _notes.Add(note);
            dbCommunicator.Add(note);
        }

        private void ManagerProfilesListBox_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) //This is the solution to my life problems!!!!
        {
            NotesListBox.Items.Refresh();
        }
    }
}
