using apiweb.models;

namespace apiweb.interfaces;
public interface ITaskService {
    public IEnumerable<models.Task> Get(string userId);
    public void Save(models.Task task);
    public void Update(Guid id,models.Task task);
    public void Delete(Guid id);
    public Boolean IsTaskByUser(Guid taskId, Guid userId);
    public models.Task GetById(Guid Id);
}

public interface ICategoryService
{
    public IEnumerable<Category> Get();
    public void Save(Category category);
    public void Update(Guid id,Category category);
    public void Delete(Guid id);

}

public interface IUserService{
    public User Login(string email, string password);

    public User GetInfo(Guid id);

    public string GenerateToken(User user);

    public User Sigup(string email, string password);

}