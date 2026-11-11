using System;

namespace FirstClass
{
    public class Person
    {
        private string name;
        private string surname;
        private DateTime birthDate;

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthDate = birthday;
        }

        public Person()
        {
            this.name = "John";
            this.surname = "Doe";
            this.birthDate = new DateTime(2000, 1, 1);
        }
        public string Name
        {
            get => name;
            set => name = value;
        }

        public string SurName
        {
            get => surname;
            set => surname = value;
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public int BirthYear
        {
            get => birthDate.Year;
            set
            {
                DateTime newBirthDate = new DateTime(value, birthDate.Month, birthDate.Day);

                if (newBirthDate <= DateTime.Today.AddYears(-20) &&
                    newBirthDate >= DateTime.Today.AddYears(-50))
                {
                    birthDate = newBirthDate;
                }
            }
        }

        public override string ToString()
        {
            return $"Имя: {name}, Фамилия: {surname}, Дата рождения: {birthDate:dd.MM.yyyy}";
        }

        public virtual string ToShortString()
        {
            return $"{name} {surname}";
        }

    }


}