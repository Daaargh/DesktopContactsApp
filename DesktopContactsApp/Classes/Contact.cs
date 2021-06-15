using SQLite;

namespace DesktopContactsApp.Classes
{
    public class Contact
    {
        // By default, when a table is created, it uses the name of the class

        // The table name can be changed by writing e.g. [Table("Person")]

        // By default, column names are the same as the property names
        // A column name can be changed by writing e.g. [Column("Familyname")]

        // Foreign keys are set as [Indexed]

        // [Ignore] attribute will prevent a property being added to the database.
        // This is useful for properties that may be useful in the program
        // but not in the database.

        // SQLite attributes are created using square brackets

        // PrimaryKey defines the property below it as the primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
