using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.database;
using WebApplication1.database.models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimaisController : ControllerBase
    {
        private dbContext _dbContext;

        public AnimaisController(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Animal>> GetAll()
        {
            return Ok(_dbContext.Animais);
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetById(int id)
        {
            try
            {
                Animal animal = _dbContext.Animais.Find(a => a.id == id);
                if (animal == null)
                    return NotFound();

                return Ok(animal);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(int id)
        {
            var animal = _dbContext.Animais.Find(a => a.id == id);

            if (animal == null)
                return NotFound();

            _dbContext.Animais.Remove(animal);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult<Animal> UpdateById(int id, [FromBody] Animal animalNovo)
        {
            if (animalNovo == null)
                return BadRequest("Dados inválidos.");

            Animal animal = _dbContext.Animais.Find(a => a.id == id);

            if (animal == null)
                return NotFound();

            if (!string.IsNullOrEmpty(animalNovo.name))
                animal.name = animalNovo.name;

            if (!string.IsNullOrEmpty(animalNovo.classification))
                animal.classification = animalNovo.classification;

            if (!string.IsNullOrEmpty(animalNovo.origem))
                animal.origem = animalNovo.origem;

            if (!string.IsNullOrEmpty(animalNovo.reproduction))
                animal.reproduction = animalNovo.reproduction;

            if (!string.IsNullOrEmpty(animalNovo.feeding))
                animal.feeding = animalNovo.feeding;

            return Ok(animal);
        }


        [HttpPatch("{id}")]
        public ActionResult<Animal> AlterarNome([FromBody] Animal body)
        {
            if (body == null || string.IsNullOrEmpty(body.name))
                return BadRequest();

            Animal animal = _dbContext.Animais.Find(a => a.id == body.id);

            if (animal == null)
                return NotFound();

            animal.name = body.name;
            return Ok(animal);
        }
    }
}
