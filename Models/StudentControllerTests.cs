using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Services.Description;
using Microsoft.Extensions.DependencyInjection;

namespace Resenje_2.Models
{
    public class StudentControllerTests
    {
        private readonly IServiceProvider serviceProvider;

        public StudentControllerTests()
        {
            //ServiceCollection services = new ServiceCollection();

            //services.AddEntityFramework()
            //    .AddInMemoryDatabase()
            //    .AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());

            //serviceProvider = services.BuildServiceProvider();
        }
        private void CreateTestData(ApplicationDbContext dbContext)
        {
            var i = 0;
            var id = 1;
            GenFu.GenFu.Configure<Student>()
                .Fill(p => p.Id, () => id++)
                .Fill(p => p.Name, () => "Name")
                .Fill(p=>p.Surname,()=>"Surname");
                

            var products = GenFu.GenFu.ListOf<Student>(20);

            dbContext.Students.AddRange(products);
            dbContext.SaveChanges();
        }
    }
}