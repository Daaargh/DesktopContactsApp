using System;
using System.IO;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Set the database name
        static string databaseName = "Contacts.db";

        // Set the database folder path
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Set the database path
        public static string databasePath = Path.Combine(folderPath, databaseName);
    }
}
