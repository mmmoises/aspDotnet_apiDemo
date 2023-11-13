using Microsoft.AspNetCore.Mvc;
using apiweb.interfaces;
using apiweb.models;
using apiweb.exception;
using Microsoft.AspNetCore.Authorization;


namespace apiweb.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoryController: ControllerBase{
    
    ICategoryService categoryService;
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ICategoryService service, ILogger<CategoryController> logger){
        _logger = logger;
        categoryService = service;
    }  

    [HttpGet]
    public IActionResult GetAllCategories(){
        try{
            return new ObjectResult(new{success=true, message="all categories",data = new{categories=categoryService.Get()}}){StatusCode=200} ;
        }catch(Exception){

            return new ObjectResult(new{success=false, message=":(" }){StatusCode=500};
        }

    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] Category category){
        try
        {   
            categoryService.Save(category);
            return new ObjectResult(new{success=true, message="Category created",}){StatusCode=201} ;
        }
        catch (Exception e)
        {   
            Console.WriteLine(e);
            return new ObjectResult(new{success=false, message=":(",errors= e }){StatusCode=500};
            //return new BadRequestResult();
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(Guid id,[FromBody] Category category){
        try
        {   
            categoryService.Update(id, category);
            return new ObjectResult(new {success=true,message="Category updated"}){StatusCode=201};
        }
        catch (NotFoundException e)
        {   
             return new ObjectResult(new{success=false, message=e.Message}){StatusCode=404};
        }
        catch (Exception)
        {   
            return new BadRequestResult();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(Guid id){
        try
        {   
            categoryService.Delete(id);
            return new ObjectResult(new {success=true,message="Category deleted"}){StatusCode=201};
        }
        catch (NotFoundException e)
        {   
            return new ObjectResult(new{success=false, message=e.Message}){StatusCode=404};
        }
        catch (Exception)
        {   
            return new BadRequestResult();
        }
    }

}