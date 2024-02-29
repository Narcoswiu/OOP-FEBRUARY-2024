using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : IIdentifiable, INameable, IBirthable
    {
        public Citizen(string id, string name, int age, string birthDate)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdate = birthDate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate { get; private set; }
    }
}
