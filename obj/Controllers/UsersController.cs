using Microsoft.AspNetCore.Mvc;
using ApiUsuarios.Models;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            users.Add(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, User user)
        {
            var usuario = users.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            usuario.Nombre = user.Nombre;
            usuario.Email = user.Email;

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = users.FirstOrDefault(x => x.Id == id);

            if (usuario == null)
                return NotFound();

            users.Remove(usuario);

            return Ok();
        }
    }
}