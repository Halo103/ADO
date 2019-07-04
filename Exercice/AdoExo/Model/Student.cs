using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoExo
{
    class Student
    {
        private int _Id, _SectionId;
        private double _YearResult;
        private string _LastName, _FirstName;
        private DateTime _Birthdate;
        private bool _Active;

        public int Id { get; set; }
        public string LastName { get { return _LastName; } }
        public string FirstName { get { return _FirstName; } }
        public DateTime BirthDate { get { return _Birthdate; }
            set {
                if (value >= new DateTime(1930, 1, 1)) _Birthdate = value;
                else _Birthdate = new DateTime(1930, 1, 1); } }
        public int SectionId { get { return _SectionId; } }
        public double YearResult { get { return _YearResult; } set { if (value >= 0 && value <= 20) _YearResult = value; else _YearResult = 0; } }
        public bool Active { get; set; }

        public Student(string lastname, string firstname, DateTime birthdate, double yearresult, int sectionid )
        {
            _Id = 0;
            _LastName = lastname;
            _FirstName = firstname;
            _Birthdate = birthdate;
            _YearResult = yearresult;
            _SectionId = sectionid;
            _Active = true;
        }
    }
}
