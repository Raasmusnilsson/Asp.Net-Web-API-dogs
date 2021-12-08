using Dogs.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Dogs.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly List<Dog> _dogCollection = new()
        {
            new Dog() { Id = 1, Name = "Dog-1" },
            new Dog() { Id = 2, Name = "Dog-2" },
        };

        public IEnumerable<Dog> GetDogs() { return _dogCollection; }
        public Dog GetDog(int id) {
            return _dogCollection.Where(item => item.Id == id).FirstOrDefault();
        }
        public void UpdateDog(Dog dog)
        {
            var index = _dogCollection.FindIndex(existingDog => existingDog.Id == dog.Id);
            _dogCollection[index] = dog;
            
        }
        public void CreateDog(Dog dog)
        {
            _dogCollection.Add(new Dog() { Name = dog.Name, Id = dog.Id });
        }
        public void DeleteDog(Dog dog)
        {
            _dogCollection.Remove(dog);
        }
    }
}
