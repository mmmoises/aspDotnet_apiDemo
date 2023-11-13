using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apiweb.exception;
using apiweb.interfaces;
using apiweb.models;
using Microsoft.IdentityModel.Tokens;

namespace apiweb.Services;

public class UserService: IUserService{

    readonly PubContext context;
    readonly IConfiguration config;

    public UserService(PubContext dbcontext, IConfiguration _conf){
        context = dbcontext;
        config = _conf;
    }

    public User Login(string email, string password){

        var current_user = context.Users.Where(u=> u.Email == email).FirstOrDefault() ?? throw new NotFoundException("El usuario no existe en la DB");
        if(current_user.IsValidatePassword(password)){
            
            return current_user;
        }
        return null;
    }

    public User GetInfo(Guid id){
        var current_user = context.Users.Find(id)?? throw new NotFoundException("usuario invalido");
        return current_user;
    }

    public string GenerateToken(User user){
        var tokenHandler = new JwtSecurityTokenHandler();
        var bytekey = Encoding.UTF8.GetBytes(config.GetSection("ConfigurationJwt:key").Get<string>()??string.Empty);

        var payloadToken = new SecurityTokenDescriptor{
            Subject= new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(payloadToken);
        return tokenHandler.WriteToken(token);
    }

    public User Sigup(string email, string password){
        User current_user = context.Users.Where(u=> u.Email == email).FirstOrDefault();
        if(current_user != null){
            throw new ArgumentException("Usuario existente");
        }
        User newUser = new(){Email= email, Password = password};
        context.Add(newUser);
        context.SaveChanges();
        return newUser;
    }

}