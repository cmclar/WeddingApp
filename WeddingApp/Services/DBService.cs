using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using WeddingApp.models;

namespace WeddingApp.Services
{
    public class DBService : iDBService
    {
        private readonly weddingContext _weddingContext;

        public DBService(weddingContext weddingContextInstance)
        {
            _weddingContext = weddingContextInstance;
        }

        public IEnumerable<AgeGroup> GetAgeGroups()
        {
            return _weddingContext.AgeGroups;
        }

        public IEnumerable<FoodChoice> GetFoodChoices()
        {
            return _weddingContext.FoodChoices;
        }

        public bool PostGuest(IEnumerable<Guest> guests)
        {
            var res = new List<Guest>();
            var existingGuests = _weddingContext.Guests.ToList();
            bool retVal = true;
            foreach (Guest g in guests)
            {
                var existing = existingGuests.FirstOrDefault(gg => gg.IdGuests == g.IdGuests);
                if (existing != null)
                {
                    existing.AgeGroupId = g.AgeGroupId;
                    existing.Attending = g.Attending;
                    existing.DessertChoiceId = g.DessertChoiceId;
                    existing.MainChoiceId = g.MainChoiceId;
                    existing.Name = g.Name;
                    existing.Notes = g.Notes;
                    existing.StarterChoiceId = g.StarterChoiceId;
                    existing.ContactNumber = g.ContactNumber;
                    res.Add(existing);
                }
                else
                {
                    res.Add(g);
                    _weddingContext.Add(g);
                }
            }

            _weddingContext.SaveChanges();

            return retVal;
        }
    }
}
