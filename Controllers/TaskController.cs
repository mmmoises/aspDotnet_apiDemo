using Microsoft.AspNetCore.Mvc;
using apiweb.interfaces;
using apiweb.models;
using apiweb.exception;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Collections.Generic;


namespace apiweb.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TaskController: ControllerBase{

    ITaskService taskService;

    public TaskController(ITaskService service){
        taskService = service;
    }


    [HttpGet]
    public IActionResult GetAllTask(){
        try{
            string? userId = User.FindFirstValue(ClaimTypes.Name);
            IEnumerable<models.Task> tasks =  taskService.Get(userId);

            return new ObjectResult(new{success=true, message="task by user",data = new{tasks}}){StatusCode=200} ;
        }catch(Exception e){

            return new ObjectResult(new{success=false, message=":("}){StatusCode=500};
        }
        
    }

    [HttpPost]
    public IActionResult CreateTask([FromBody] models.Task task){
        try
        {   task.UserId = new Guid(User.FindFirstValue(ClaimTypes.Name));
            taskService.Save(task);
            return new ObjectResult(new {success=true,message="task created"}){StatusCode=201};
        }
        catch (Exception)
        {   
            return new ObjectResult(new{success=false, message=":("}){StatusCode=500};
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTask(Guid id,[FromBody] models.Task task){
        try
        {  
            Guid userId = new (User.FindFirstValue(ClaimTypes.Name));
            if(!taskService.IsTaskByUser(id,userId)){
                throw new LogicException("The task doesn't belong to the user");
            }

            task.UserId = userId;
            taskService.Update(id, task);
            return new ObjectResult(new {success=true,message="task updated"}){StatusCode=201};
        }
        catch(LogicException e){
            return new ObjectResult(new{success=false, message=e.Message}){StatusCode=409};
        }
        catch (NotFoundException e)
        {   
            return new ObjectResult(new{success=false, message=e.Message}){StatusCode=404};
        }
        catch (Exception)
        {   
            return new ObjectResult(new{success=false, message=":("}){StatusCode=500};
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(Guid id){
        try
        {   Guid userId = new (User.FindFirstValue(ClaimTypes.Name));
            if(!taskService.IsTaskByUser(id,userId )){
                throw new LogicException("The task doesn't belong to the user");
            }
            taskService.Delete(id);
            return new ObjectResult(new {success=true,message="task deleted"}){StatusCode=200};
        }catch(LogicException e){
            return new ObjectResult(new{success=false, message=e.Message}){StatusCode=409};
        }
        catch (NotFoundException e)
        {   
            Console.WriteLine(e.Message);
            return new ObjectResult(new{success=false, message=e.Message}){StatusCode=400};
        }
        catch (Exception)
        {   
            return new ObjectResult(new{success=false, message=":("}){StatusCode=500};
        }
    }


}