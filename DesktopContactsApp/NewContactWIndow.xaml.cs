using DesktopContactsApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for NewContactWIndow.xaml
    /// </summary>
    public partial class NewContactWIndow : Window
    {
        public NewContactWIndow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Save contact
            Contact contact = new Contact()
            {
                // Contact info is assigned to the text boxes through the properties
                // of the Contact object as set in the Contact class

                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };


            // Create connection to the database

            // This is a using statement.  It allows us to define one element that is only
            // going to exist within this context.  It's scope is only within the brackets.
            // The object (in this case 'connection' has to be of a type that implements
            // The IDisposable interface which disposes of the object once the code is executed.
            // In this case, the connection will be closed once the code is executed.

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                // If the table exists, this will be ignored, the table will not be created again
                connection.CreateTable<Contact>();

                // Insert the contact into the Contacts table
                connection.Insert(contact);
            };

            Close();
        }
    }
}
