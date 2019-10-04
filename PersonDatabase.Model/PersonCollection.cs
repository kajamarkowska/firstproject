﻿using System;
using System.Collections.Generic;
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

        // konstruktor z parametrem pozwalającym określić nazwę pliku, z którego mają zostać
        // wczytane osoby i dodane do kolekcji
        public PersonCollection(string fileName)
        {
            persons = new List<Person>();
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string firstname, lastname;
                    int age;

                    firstname = reader.ReadLine();
                    lastname = reader.ReadLine();
                    age = int.Parse(reader.ReadLine());

                    Person person = new Person(firstname, lastname, age);
                    persons.Add(person);

                    

                }


            }

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
                }

            }
        }
    }
}
