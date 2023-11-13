
using apiweb.exception;
using apiweb.interfaces;
using apiweb.models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace apiweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase{

    protected readonly IUserService userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService _service, ILogger<UserController> logger){
        userService = _service;
        _logger=logger;
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] object rawData){
        try{

            var data = JsonConvert.DeserializeObject<dynamic>(rawData.ToString());
            
            var email = data.email.ToString();
            var pass = data.password.ToString();

            var user = userService.Login(email, pass) ?? throw new NotFoundException("Correo o contraseña  incorrecta");
            var token = userService.GenerateToken(user);
            
            return new JsonResult(new{success=true, message="Usuario autenticado", data=new{token}});
        }catch (NotFoundException e )
        {   
            Console.WriteLine(e);
            return new JsonResult(new{success=false, message=e.Message}){StatusCode=400};
        }
        catch (Exception e)
        {   
            Console.WriteLine(e);
            return new ObjectResult(new{success=false, message=":("}) {StatusCode = 500};
        }
    }

    [HttpPost]
    [Route("signup")]
    public IActionResult Sigup([FromBody] object rawData)
    {
        try
        {
            dynamic data = JsonConvert.DeserializeObject<dynamic>(rawData.ToString())?? throw new ArgumentException("Error ");
            string email = data.email.ToString()?? throw new ArgumentException("Email error");
            string pass = data.password.ToString()?? throw new ArgumentException("Password error ");

            User newUser = userService.Sigup(email,pass);
            var token = userService.GenerateToken(newUser);

            return new JsonResult(new{success=true, message="Usuario creado", data=new{token} });
        }
        catch (ArgumentException e)
        {
            _logger.LogInformation(e.ToString() );
            return new ObjectResult(new{success=false, message=e.Message}) {StatusCode = 400};
        }
        catch (Exception e)
        {   
            _logger.LogInformation(e.ToString() );
            return new ObjectResult(new{success=false, message=":("}) {StatusCode = 500};
        }
    }

    
}