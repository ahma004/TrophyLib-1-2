using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyLib
{
    public class TrophiesRepository
    {
        private readonly List<Trophy> _trophies = new();
        private int _nextId = 1;

        public TrophiesRepository()
        {
            // Seed med mindst 5 trofæer
            Add(new Trophy { Competition = "DM 100m", Year = 2018 });
            Add(new Trophy { Competition = "VM Marathon", Year = 2019 });
            Add(new Trophy { Competition = "Byløb", Year = 2015 });
            Add(new Trophy { Competition = "Klubmesterskab", Year = 2017 });
            Add(new Trophy { Competition = "EM Halvmaraton", Year = 2020 });
        }

        public List<Trophy> Get(int? year = null, string? sortBy = null)
        {
            IEnumerable<Trophy> query = _trophies.Select(t => new Trophy(t));

            if (year.HasValue)
            {
                query = query.Where(t => t.Year == year.Value);
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = sortBy.ToLower();
                query = sortBy switch
                {
                    "competition" => query.OrderBy(t => t.Competition),
                    "year" => query.OrderBy(t => t.Year),
                    _ => query
                };
            }

            return query.ToList();
        }

        public Trophy? GetById(int id)
        {
            return _trophies.FirstOrDefault(t => t.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            if (trophy == null) throw new ArgumentNullException(nameof(trophy));

            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy? Update(int id, Trophy values)
        {
            var existing = GetById(id);
            if (existing == null) return null;

            existing.Competition = values.Competition;
            existing.Year = values.Year;

            return existing;
        }
    }
}
