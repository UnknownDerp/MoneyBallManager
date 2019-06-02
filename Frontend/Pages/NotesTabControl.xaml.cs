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
using Frontend.Dialogs;
using Frontend.Extensions;

namespace Frontend.Pages
{
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
            EditDeletePair.Visibility = Visibility.Visible;
            SaveCancelPair.Visibility = Visibility.Collapsed;
        }

        private void ToggleButtonPairs()
        {
            EditDeletePair.Visibility = EditDeletePair.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            SaveCancelPair.Visibility = SaveCancelPair.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ResetTextBox(TextBox textBox)
        {
            textBox.Text = "";
        }

        private void Save_ButtonClick(object sender, RoutedEventArgs e)
        {
            var note = new Note() { DateEdited = DateTime.Now.ToMbmString(), Message = NoteTextBox.Text };
            _notes.AddAndSave(note);
            ResetTextBox(NoteTextBox);
        }

        private void ManagerProfilesListBox_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) //This is the solution to my life problems!!!!
        {
            NotesListBox.Items.Refresh();
        }

        private void NotesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var messageIndex = NotesListBox.SelectedIndex;
            if (messageIndex != -1)
            {
                TextBoxReadonly.Text = _notes[messageIndex].Message;
            }
        }

        private void Delete_ButtonClick(object sender, RoutedEventArgs e)
        {
            var dbCommunicator = new DatabaseCommunicator();
            var confirmDialog = new ConfirmDialog() { Owner = Window.GetWindow(this) };
            confirmDialog.ShowDialog();
            if (confirmDialog.DialogResult != null && confirmDialog.DialogResult == true)
            {
                if (NotesListBox.SelectedItem is Note selectedItem)
                {
                    dbCommunicator.Remove<Note>(x => x.Id == selectedItem.Id);
                    _notes.Remove(selectedItem);
                    ResetTextBox(TextBoxReadonly);
                }
            }
        }

        private void EditButton_OnClick_ButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxReadonly.IsEnabled = true;
            ToggleButtonPairs();
        }

        private void Cancel_ButtonClick(object sender, RoutedEventArgs e)
        {
            TextBoxReadonly.IsEnabled = false;
            ToggleButtonPairs();
        }

        private void SaveEdit_ButtonClick(object sender, RoutedEventArgs e)
        {
            var dbCommunicator = new DatabaseCommunicator();
            Cancel_ButtonClick(sender, e);

            if (NotesListBox.SelectedItem is Note selectedItem)
            {
                selectedItem.Message = TextBoxReadonly.Text;
                dbCommunicator.Get<Note>(x => x.Id == selectedItem.Id).Message = TextBoxReadonly.Text;
                dbCommunicator.SaveChanges();
            }
        }
    }
}
