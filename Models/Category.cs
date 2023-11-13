
using System.Text.Json.Serialization;

namespace apiweb.models;

public class Category{

    public Guid Id {get; set;}

    public string Name {get; set;}

    public string Description {get; set;}

    [JsonIgnore]
    public ICollection<Task>? Tasks {get; set;}

    public int Weight {get; set;}

}