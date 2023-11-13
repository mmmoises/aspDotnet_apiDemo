using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiweb.models;

public class Task
{
    public Guid Id {get; set;}

    //[ForeignKey("CategoryId")]
    public Guid CategoryId {get;set;}

    public string Title {get; set;}

    public string Description {get; set;}    
    
    //[Required]
    public Priority Priority {get; set;}
    
    public DateTime Created_at {get; set;}

    public virtual Category? Category {get; set;}

    public string? Resume{get;set;}

    public Guid? UserId {get;set;}

    public virtual User? User {get; set;}

}

public enum Priority{
    low,
    mid,
    high
}