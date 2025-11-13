using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophiesRepository
    {
        private readonly List<Trophy> _trophies ;
        private int _nextId = 1;

        public TrophiesRepository()
        {
            _trophies.AddRange(new[]
           {
                new Trophy(1, "World Cup", 2018),
                new Trophy(2, "Champions League", 2020),
                new Trophy(3, "Olympics", 2016),
                new Trophy(4, "National League", 2019),
                new Trophy(5, "City Cup", 2021)
            });
            if (_trophies.Count > 0)
                _nextId = _trophies.Max(t => t.Id) + 1;
        }

    }
    }
