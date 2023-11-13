using apiweb.models;
using Microsoft.EntityFrameworkCore;

namespace apiweb;

public class PubContext: DbContext
{
    public DbSet<models.Task> Tasks {get; set;}
    public DbSet<Category> Categories {get; set;}

    public DbSet<User> Users {get;set;}

    public PubContext(DbContextOptions<PubContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(new Category() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Name = "Actividades pendientes", Weight = 20});
        categoriesInit.Add(new Category() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Name = "Actividades personales", Weight = 50});



        modelBuilder.Entity<Category>(category =>{
            category.ToTable("Category");
            category.HasKey(c => c.Id);
            category.Property(c => c.Name).IsRequired().HasMaxLength(150);
            category.Property(c => c.Description).IsRequired(false);
            category.HasData(categoriesInit);
        });

        List<models.Task> tareasInit = new List<models.Task>();

        tareasInit.Add(new models.Task() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Priority = Priority.mid, Title = "Pago de servicios publicos", Created_at = DateTime.UtcNow });
        tareasInit.Add(new models.Task() { Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoryId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Priority = Priority.low, Title = "Terminar de ver pelicula en netflix", Created_at = DateTime.UtcNow });


        modelBuilder.Entity<models.Task>(task =>{
            task.ToTable("Task");
            task.HasKey(t => t.Id);
            task.HasOne(t => t.Category).WithMany(t => t.Tasks).HasForeignKey(t => t.CategoryId);

            task.HasOne(t => t.User).WithMany(t => t.Tasks).HasForeignKey(t => t.UserId).IsRequired(false);


            task.Property(t => t.Title).IsRequired().HasMaxLength(200) ;
            task.Property(t=> t.Description).IsRequired(false);
            task.Property(t=> t.Created_at);
            task.Property(t => t.Priority);

            task.Ignore(t => t.Resume);

            task.HasData(tareasInit);
        });

        List<User> userInit = new List<User>();
        userInit.Add(new User(){Id = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"),Email="moises@morales.com", Password= BCrypt.Net.BCrypt.HashPassword("pass123")});

        modelBuilder.Entity<User>(user =>{
            user.ToTable("User");
            user.HasKey(c => c.Id);
            user.Property(c => c.Email).IsRequired().HasMaxLength(150);
            user.Property(c => c.Password).IsRequired();
            user.HasData(userInit);
        });
    }
}