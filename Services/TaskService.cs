using apiweb.interfaces;
using apiweb.exception;
using Microsoft.EntityFrameworkCore;

namespace apiweb.Services;

public class TaskService: ITaskService
{
    public PubContext context;
    public TaskService(PubContext dbcontext){
        context = dbcontext;
    }
    public IEnumerable<models.Task> Get(string userId){

        var tasks = context.Tasks.Where(item=>item.UserId == new Guid(userId)).Include(t=>t.User) ;
        return tasks;
    }
    public models.Task GetById(Guid Id){

        var task = context.Tasks.Where(item=>item.Id == Id).FirstOrDefault()?? throw new NotFoundException("Task doesn't exist") ;
        return task;
    }
    public void Save(models.Task task){
        context.Add(task);
        context.SaveChanges();
    }
    public void Update(Guid id,models.Task task){

        var current_task = context.Tasks.Find(id) ?? throw new NotFoundException("Task doesn't exist");

        current_task.Title = task.Title;
        current_task.Description = task.Description;
        current_task.Priority = task.Priority;

        context.SaveChanges();
    }
    public void Delete(Guid id){
        var current_task = context.Tasks.Find(id)?? throw new NotFoundException("Task doesn't exist");
        
        context.Remove(current_task);
        context.SaveChanges();
    }

    public Boolean IsTaskByUser(Guid taskId, Guid userId){
        return context.Tasks.Where(item=>item.Id == taskId && item.UserId == userId).FirstOrDefault()!=null;
    }
}


