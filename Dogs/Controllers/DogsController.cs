using Dogs.Entities;
using Dogs.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogRepository _repository;

        public DogsController(IDogRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Dog> GetDogs() { return _repository.GetDogs(); }

        [HttpGet("{id}")]
        public ActionResult<Dog> GetDog(int id) { return _repository.GetDog(id);}

        [HttpPut("{id}")]
        public ActionResult<Dog> UpdateDog([FromBody]Dog v, int id)
        {
            var existingItem = _repository.GetDog(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = v.Name;
            existingItem.Id = v.Id;

            _repository.UpdateDog(existingItem);

            return Ok(existingItem);
        }
        [HttpPost]
        public void CreateDog(Dog dog)
        {
            _repository.CreateDog(dog);           
        }
        [HttpDelete]
        public void DeleteDog(int id)
        {
            var dog = _repository.GetDog(id);
            _repository.DeleteDog(dog);
             
        }

    }
}
