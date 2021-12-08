using Dogs.Entities;
using System.Collections.Generic;

namespace Dogs.Repositories
{
    public interface IDogRepository
    {
        IEnumerable<Dog> GetDogs();
        Dog GetDog(int id);
        void UpdateDog(Dog dog);
        void CreateDog(Dog dog);
        void DeleteDog(Dog dog);
    }
}
