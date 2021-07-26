using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingApp.models;

namespace WeddingApp.Services
{
    public interface iDBService
    {
        public IEnumerable<AgeGroup> GetAgeGroups();
        public IEnumerable<FoodChoice> GetFoodChoices();
        public bool PostGuest(IEnumerable<Guest> guests);
    }
}
