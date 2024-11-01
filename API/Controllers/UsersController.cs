using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context): ControllerBase
{
    /*[HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        var users= context.Users.ToList();
        return Ok(users);
    }*/

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users= await context.Users.ToListAsync();
        return Ok(users);
    }


    [HttpGet("{id:int}")]
    public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
    {
        var user= await context.Users.FindAsync(id);
        
        if (user==null) return NotFound();

        return Ok(user);
    }
}