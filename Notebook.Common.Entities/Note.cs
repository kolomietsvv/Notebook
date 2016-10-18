using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Common.Entities
{
    public class Note
    {
        //* in the most areas of North America, 
        //telephone numbers in metropolitan communities consisted of a 
        //combination of digits and letters, starting in the 1920s. (en.wikipedia.org)

        //** the oldest woman was born in 21 February 1875 and died 4 August 1997. (en.wikipedia.org)

        private string surname;
        private string name;
        private int yearOfBirth;
        private string phoneNumber;
        private int id;

        public int Id
        {
            get { return id;}
            set { id = value; }

        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int YearOfBirth
        {
            get { return yearOfBirth; }
            set
            {
                if (value < 1875) //**
                    throw new ArgumentOutOfRangeException("The person, who was born in this year, could not use the phone");
                if (value > DateTime.Now.Year)
                    throw new ArgumentOutOfRangeException("The person haven't born yet");
                yearOfBirth = value;
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string ToString(string fieldSeparator)
        {
            return id + fieldSeparator + surname + fieldSeparator + name + fieldSeparator + yearOfBirth + fieldSeparator + phoneNumber;
        }
        public string ToString()
        {
            return id + ";" + surname + ";" + name + ";" + yearOfBirth + ";" + phoneNumber;
        }
    }
}
