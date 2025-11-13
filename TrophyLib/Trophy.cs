using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class Trophy
    {
        private int _id;
        private string _competition = string.Empty;
        private int _year;

        public int Id
        {
            get => _id;
            set
            {
                // Id: "et tal" 
                _id = value;
            }
        }

        public string Competition
        {
            get => _competition;
            set
            {
                // Må ikke være null og min. 3 tegn (opgavekrav)
                // KAST: ArgumentNullException ved null; ArgumentException ved længde < 3
                if (value is null)
                    throw new ArgumentNullException(nameof(Competition), "Competition må ikke være null.");
                if (value.Trim().Length < 3)
                    throw new ArgumentException("Competition skal være mindst 3 tegn.", nameof(Competition));

                _competition = value.Trim();
            }
        }

        public int Year
        {
            get => _year;
            set
            {
             
                if (value < 1970 || value > 2025)
                    throw new ArgumentOutOfRangeException(nameof(Year), "Year skal være mellem 1970 og 2025 (inkl.).");
                _year = value;
            }
        }

        public Trophy() { }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition; // validerer
            Year = year;               // validerer
        }

        public override string ToString()
            => $"#{Id}: {Competition} ({Year})";
    }
}