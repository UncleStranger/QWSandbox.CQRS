using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Services.Default
{
	public class UserDBService : IUserDBService
    {
        private List<UserModel> _users = new List<UserModel>
        {
            new()
            {
                Id = Guid.Parse("46c8ad8a-d4af-4b73-b098-4f3ffe37d2c6"),
                Name = "Лука Мудищев",
                Email = "luka@mudishev.com",
                Comment = "Лука Мудищев был дородный\r\nМужчина лет так сорока.\r\nЖил вечно пьяный и голодный\r\nВ каморке возле кабака."
            },
            new()
            {
                Id = Guid.Parse("d78a88fd-5694-4356-80e4-333db9b324f0"),
                Name = "Василий Пупкин",
                Email = "v@pupkin.com",
                Comment = "Комментарий Василия Пупкина"
            }
        };

        public async Task<List<UserModel>> GetUsers()
        {
            return await Task.FromResult(_users);
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(u => u.Id == id));
        }

        public async Task AddUser(UserModel user)
        {
            _users.Add(user);
        }
    }
}
