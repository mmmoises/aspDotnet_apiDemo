using System.Text.Json.Serialization;

namespace apiweb.models;

public class User{

    public Guid Id {get;set;}

    public string Email {get; set;}

    private string _password;

    public string Password {
        get{
            return "";
        }
        set{
            this._password = BCrypt.Net.BCrypt.HashPassword(value);
        }
    }

    [JsonIgnore]
    public ICollection<Task> Tasks {get; set;}

    public Boolean IsValidatePassword(string password){
        if(BCrypt.Net.BCrypt.Verify(password, this._password)){
            
            return true;
        }
        return false;
    }
}