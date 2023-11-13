using apiweb.exception;
using apiweb.interfaces;
using apiweb.models;

namespace apiweb.Services;

public class CategoryService: ICategoryService
{
    PubContext context;

    private readonly ILogger<CategoryService> _logger;

    public CategoryService(PubContext dbContext, ILogger<CategoryService> logger){
        _logger = logger;
        context = dbContext;
    }
    public IEnumerable<Category> Get()
    {
        return context.Categories;
    }

    public void Save(Category category){
        context.Add(category);
        context.SaveChanges();
    }
    public void Update(Guid id , Category category){

       
        var current_category = context.Categories.Find(id)?? throw new NotFoundException("Category doesn't exist");
        
        current_category.Name = category.Name;
        current_category.Description = category.Description;
        current_category.Weight = category.Weight;
        context.SaveChanges();
        
    }

    public void Delete(Guid id){
        var current_category = context.Categories.Find(id)?? throw new NotFoundException("Category doesn't exist");

        context.Remove(current_category);
        context.SaveChanges();
    }
}

