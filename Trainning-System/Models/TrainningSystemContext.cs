using Microsoft.EntityFrameworkCore;

namespace Trainning_System.Models
{
    public class TrainningSystemContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<crsResult> CrsResult { get; set; }
        public DbSet<Department> Department { get; set; }

        public TrainningSystemContext():base()
        {
            
        }

        /// using during injection dbcontext on repositories.
        public TrainningSystemContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=TrainningSystemContext;Integrated Security=True;Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Course Data
            modelBuilder.Entity<Course>()
                .HasData(new Course { Id = 1, Name = "MVC", Degree = 100, Min_Degree = 60, DepartmentId=1 });
            modelBuilder.Entity<Course>()
                .HasData(new Course { Id = 2, Name = "Entity Framework", Degree = 100, Min_Degree = 60, DepartmentId=1 });
            modelBuilder.Entity<Course>()
                .HasData(new Course { Id = 3, Name = "LinQ", Degree = 100, Min_Degree = 60, DepartmentId=1 });
            modelBuilder.Entity<Course>()
                .HasData(new Course { Id = 4, Name = "Angular", Degree = 100, Min_Degree = 60, DepartmentId = 2 });
            modelBuilder.Entity<Course>()
                .HasData(new Course { Id = 5, Name = "NodeJS", Degree = 100, Min_Degree = 60, DepartmentId = 2 });
            #endregion

            #region Trainee Data
            modelBuilder.Entity<Trainee>()
                .HasData(new Trainee { Id = 1, Name = "Men3m", Grade="3", Address="Paris", Image="men3m.png", DepartmentId=1 });
            modelBuilder.Entity<Trainee>()
                .HasData(new Trainee { Id = 4, Name = "Ahmed", Grade = "3", Address = "Chanzelizah", Image = "man1.png", DepartmentId = 1 });
            modelBuilder.Entity<Trainee>()
                .HasData(new Trainee { Id = 2, Name = "John Doe", Grade = "2", Address = "Tokyo", Image = "man3.png", DepartmentId = 1 });
            modelBuilder.Entity<Trainee>()
                .HasData(new Trainee { Id = 3, Name = "Mark", Grade = "1", Address = "London", Image = "man4.png", DepartmentId = 2 });
            #endregion

            #region crsResult Data
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 1, Degree = 20, CourseId = 4, TraineeId = 3 });
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 2, Degree = 80, CourseId = 1, TraineeId = 1 });
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 3, Degree = 60, CourseId = 5, TraineeId = 2 });
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 4, Degree = 55, CourseId = 1, TraineeId = 4 });
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 5, Degree = 37, CourseId = 4, TraineeId = 1 });
            modelBuilder.Entity<crsResult>()
                .HasData(new crsResult { Id = 6, Degree = 95, CourseId = 5, TraineeId = 1 });
            #endregion

            #region Instructor Data
            modelBuilder.Entity<Instructor>()
                .HasData(new Instructor { Id = 2, Name = "Killua", salary = 30000, Address = "Hunter X Hunter", Image = "man1.jpg", DepartmentId = 1, CourseId = 2 });
            modelBuilder.Entity<Instructor>()
                .HasData(new Instructor { Id = 1, Name = "Gon Freecs", salary = 50000, Address = "Hunter X Hunter", Image = "man2.jpeg", DepartmentId = 1, CourseId = 3 });
            modelBuilder.Entity<Instructor>()
                .HasData(new Instructor { Id = 3, Name = "Pitou", salary = 20000, Address = "Hunter X Hunter", Image = "girl.jpeg", DepartmentId = 2, CourseId = 1 });
            #endregion

            #region Department Data
            modelBuilder.Entity<Department>()
                .HasData(new Department { Id = 1, Name = "SD", Manager="Mohamed ElShafei"});
            modelBuilder.Entity<Department>()
                .HasData(new Department { Id = 2, Name = "OS", Manager = "Omnia" });
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}
