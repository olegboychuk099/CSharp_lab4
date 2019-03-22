using System;
using System.Text.RegularExpressions;
using Csharp_laba2.Tools;

namespace Csharp_laba2.Model
{
    class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private DateTime _birthDay;
        private string _email;
        private readonly string[] _chineseSigns  = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        #endregion
        #region Constructors
        internal Person(string name, string surname, string email, DateTime birthDay)
        {
                ValidName(name, surname);
                ValidBirthday(birthDay);
                ValidBirthday(birthDay);
                ValidEmail(email);
            
            _name = name;
            _surname = surname;
            _email = email;
            _birthDay = birthDay;
        }
        internal Person(string name, string surname, string email, int age) : this(name, surname, email, DateTime.Today)
        {
        }
        internal Person(string name, string surname, DateTime birthDay, int age) : this(name, surname, "null", birthDay)
        {
        }
        #endregion
        #region Properties
        private string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private string Surname
        {
            get
            {
                return _surname;
            }
             set
            {
                _surname = value;
            }
        }

        private string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        private DateTime BirthDay
        {
            get
            {
                return _birthDay;
            }
            set
            {
                _birthDay = value;
            }
        }

        private bool IsAdult
        {
            get
            {
                var today = DateTime.Today;
                var a = (today.Year * 100 + today.Month) * 100 + today.Day;
                var b = (_birthDay.Year * 100 + _birthDay.Month) * 100 + _birthDay.Day;
                return (a - b) / 10000 >= 18;
            }
        }
        


        public bool IsBirthDay
        {
            get
            {
                return (_birthDay.Day == DateTime.Now.Day && _birthDay.Month == DateTime.Now.Month);
            }
        }

        private string SunSign
        {
            get
            {
                int moth = BirthDay.Month;
                int day = BirthDay.Day;
                switch (moth)
                {
                    case 1:
                        return day <= 20 ? "Capricorn" : "Aquarius";
                    case 2:
                        return day <= 19 ? "Aquarius" : "Pisces";
                    case 3:
                        return day <= 20 ? "Pisces" : "Aries";
                    case 4:
                        return day <= 20 ? "Aries" : "Taurus";
                    case 5:
                        return day <= 21 ? "Taurus" : "Gemini";
                    case 6:
                        return day <= 22 ? "Gemini" : "Cancer";
                    case 7:
                        return day <= 22 ? "Cancer" : "Leo";
                    case 8:
                        return day <= 23 ? "Leo" : "Virgo";
                    case 9:
                        return day <= 23 ? "Virgo" : "Libra";
                    case 10:
                        return day <= 23 ? "Libra" : "Scorpio";
                    case 11:
                        return day <= 22 ? "Scorpio" : "Sagittarius";
                    case 12:
                        return day <= 21 ? "Sagittarius" : "Capricorn";
                    default:
                        throw new ArgumentException("Inappropriate format of month !");
                }
            }
        }

        private string ChineseSign
        {
            get
            {
                var date = _birthDay.Year;
                return _chineseSigns[(date - 4) % 12];
            }
        }


        private bool IsBirthday()
        {
            return DateTime.Today.Month == _birthDay.Month && DateTime.Today.Day == _birthDay.Day;
        }

        private void ValidName(string name, string surname)
        {
            if (surname.Length < 3 || name.Length < 2 || !Regex.IsMatch(name, @"^[a-zA-Z]+$") || !Regex.IsMatch(surname, @"^[a-zA-Z]+$"))
                throw new NameException($"This name isn`t correct {name} {surname}");
        }

        private void ValidBirthday(DateTime birthday)
        {
            if (DateTime.Today.Year - birthday.Year >= 135)
                throw new PastBirthdayException($"Date isn`t correct (long time ago): {birthday.ToShortDateString()}");
            if (birthday > DateTime.Today)
                throw new FutureBirthdayException($"Date isn`t correct (not yet come): {birthday.ToShortDateString()}");
        }

        private void ValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                throw new EmailException($"Email isn`t correct: {email}");
        }
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                $"Surname: {Surname}\n" +
                $"Email: {Email}\n" +
                $"Date of birth: {BirthDay.ToShortDateString()}\n" +
                $"Adult: {IsAdult}\n" +
                $"Sign: {SunSign}\n" +
                $"Chinese Sign: {ChineseSign}\n";
        }
        #endregion
    }
}