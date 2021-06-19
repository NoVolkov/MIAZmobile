using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTest.models
{
    class Patient
    {
        //класс клиента
        public int Id { get; set; }
        public string Snils { get; set; } //снилс
        public string Name { get; set; } //имя
        public string Surname { get; set; } //фамилия
        public string Patronymic { get; set; } //отчество
        public DateTime DateOfBirthDay { get; set; } // возраст
        public double Height { get; set; }// рост
        public double Weight { get; set; }//вес
        public Patient ()
        {

        }
        public Patient(string snils, string name, string surname, string patronymic, DateTime dateOfBirthDay, double height, double weight)
        {
            Snils = snils;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            DateOfBirthDay = dateOfBirthDay;
            Height = height;
            Weight = weight;
        }
    }
}
