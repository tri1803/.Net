using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Role = Temp.DataAccess.Data.Role;

namespace Temp.DataAccess
{
    public static class DbInitial
    {
        public static void Initial(DataContext context, IConfiguration configuration)
        {
            if (!((RelationalDatabaseCreator) context.Database.GetService<IDatabaseCreator>()).Exists())
            {
                context.Database.EnsureCreated();
                if (!context.Roles.Any())
                {
                    var admin = new Role
                    {
                        Name = Constants.Role.Admin
                    };
                    var user = new Role
                    {
                        Name = Constants.Role.User
                    };
                    context.Add(admin);
                    context.Add(user);
                    context.SaveChanges();
                }
                //if (!context.Users.Any())
                //{
                //    var accountAdmin = new User
                //    {
                //        Username = Constants.DbInit.DfAdmin,
                //        Password = Constants.DbInit.DfPassword,
                //        RoleId = (int) Common.Infrastructure.Role.Admin,
                //        CreateDate = DateTime.Now,
                //        ExpiredDate = DateTime.MaxValue,
                //        Type =(int)UserType.Approve
                //    };
                //    var accountUser = new User
                //    {
                //        Username = Constants.DbInit.DfUser,
                //        Password = Constants.DbInit.DfPassword,
                //        RoleId = (int) Common.Infrastructure.Role.User,
                //        CreateDate = DateTime.Now,
                //        ExpiredDate = DateTime.Now,
                //        Type = (int)UserType.None
                //    };
                //    context.Users.Add(accountAdmin);
                //    context.Users.Add(accountUser);
                //    context.SaveChanges();
                //}

                //if (!context.Categories.Any())
                //{
                //    for (int i = 0; i < 50; i++)
                //    {
                //        var cate = new Category
                //        {
                //            Name = Constants.DbInit.DfCate + " " + i
                //        };
                //        context.Categories.Add(cate);
                //    }

                //    context.SaveChanges();
                //}
                
            }
        }
    }
}