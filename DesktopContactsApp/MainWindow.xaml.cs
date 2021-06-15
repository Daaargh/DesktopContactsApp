using DesktopContactsApp.Classes;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create new NewContactWindow
            NewContactWIndow newContactWIndow = new NewContactWIndow();

            // Display the NewContactWindow instance
            newContactWIndow.ShowDialog();

            // .ShowDialog() method makes the window modal

            ReadDatabase();
        }

        void ReadDatabase()
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();

                // Because OrderBy returns an IOrderedEnumarable, it is cast to a list
                // so it can be assigned to the contacts again.
                contacts = conn.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();
            };

            if (contacts != null)
            {
                //foreach (var c in contacts)
                //{
                //    contactsListView.Items.Add(new ListViewItem()
                //    {
                //        Content = c
                //    });
                //}
                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            //  The filteredList variable creation in full using variable name filteredList2
            var filteredList2 = (from c2 in contacts
                                 where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                 orderby c2.Name
                                 select c2).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if (selectedContact != null)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContact);
                contactDetailsWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}
