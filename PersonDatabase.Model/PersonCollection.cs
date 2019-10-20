using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;


namespace PersonDatabase.Model
{
    // klasa będąca kartoteką (kolekcją) osób
    public class PersonCollection
    {
        // lista osób jako prywatne pole klasy PersonCollection
        private List<Person> persons;


        // konstruktor bez parametrów
        public PersonCollection()
        {
            persons = new List<Person>();

        }

        public List<Person> Persons
        {
            get
            {
                return persons;

            }
            set
            {
                persons = value;

            }

        }
        // konstruktor z parametrem pozwalającym określić nazwę pliku, z którego mają zostać
        // wczytane osoby i dodane do kolekcji
        public PersonCollection(string fileName)
        {
            persons = new List<Person>();

            using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + fileName)) 
            {
                connect.Open();
                using(SQLiteCommand command = connect.CreateCommand())
                {
                    command.CommandText = "select * from person";
                    SQLiteDataReader reader = command.ExecuteReader();

                    while( reader.Read())
                    {
                        Person person = new Person();

                        person.Id = Convert.ToInt32( reader["Id"]);
                        person.FirstName = Convert.ToString(reader["FirstName"]);
                        person.LastName = Convert.ToString(reader["LastName"]);
                        person.Age = Convert.ToInt32(reader["Age"]);
                        person.Sex = Convert.ToString(reader["Sex"]);
                        person.Height = Convert.ToInt32(reader["Height"]);



                        persons.Add(person);
                    }

                }

            }

        }

        public void Delete(int index)
        {
            persons.RemoveAt(index);
        }
        public void Delete(Person person)
        {
            persons.Remove(person);

        }


        // metoda pozwalająca dodać osobę do kolekcji
        public void Add(Person person)
        {
            persons.Add(person);
        }

        // metoda pozwalająca pobrać osobę na danym indeksie w kolekcji
        public Person GetAt(int index)
        {
            return persons[index];
        }

        // właściwość zwracająca ilość osób w kolekcji
        public int Count
        {
            get
            {
                return persons.Count;
            }
        }


        // metoda pozwalająca zapisać osoby z kolekcji do pliku
        public void Save(string fileName)
        {
           using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Person person in persons)
                {
                    writer.WriteLine(person.FirstName);
                    writer.WriteLine(person.LastName);
                    writer.WriteLine(person.Age);
                    writer.WriteLine(person.Sex);
                    writer.WriteLine(person.Height);
                }

            }
        }
    }
}
