using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_1
{
    public class TrophiesRepository
    {
        private int _nextId = 1;
        private readonly List<Trophy> _trophies = new();
        public TrophiesRepository()
        {
            // Adding at least 5 Trophy objects to the list
            _trophies.Add(new Trophy { Id = _nextId++, Competition = "Badminton", Year = 2020 });
            _trophies.Add(new Trophy { Id = _nextId++, Competition = "Æblekast", Year = 2018 });
            _trophies.Add(new Trophy { Id = _nextId++, Competition = "Fioskeri", Year = 2019 });
            _trophies.Add(new Trophy { Id = _nextId++, Competition = "Cupping", Year = 2021 });
            _trophies.Add(new Trophy { Id = _nextId++, Competition = "Cupping", Year = 2016 });
        }
        public List<Trophy> GetAll()
        {
            return new List<Trophy>(_trophies);
        }

        public IEnumerable<Trophy> Get(int? filteryear = null, string? orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);

            if (filteryear != null)
            {
                result = result.Where(test => test.Year == filteryear);


            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "year":
                        result = result.OrderBy(t => t.Year);
                        break;
                    default:
                        break;
                }


            }
            return result;

        }
        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }


        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id =_nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null) { return null; }
            _trophies.Remove(trophy);
            return trophy;
        }
        public Trophy? Update(int id, Trophy values)
        {
            values.Validate();
            Trophy? existingTropgy =GetById(id);
            if (existingTropgy == null) {return null; }
            existingTropgy.Competition = values.Competition;
            existingTropgy.Year = values.Year;
            return existingTropgy;
        }
    }
}
