using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using QWSandbox.CQRS.Domain.Models.User;

namespace QWSandbox.CQRS.Web.Services.Default
{
    public class UserCacheService: IUserCacheService
    {
        public const string UsersCacheKey = "UsersCacheKey";

        private readonly IMemoryCache _memoryCache;
        public UserCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public async Task AddUser(UserModel user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            List<UserModel> users = await GetUsers();
            users.Add(user);

            SaveUsers(users);
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _memoryCache.GetOrCreateAsync<List<UserModel>>(UsersCacheKey, entry =>
            {
                //entry.SlidingExpiration = TimeSpan.FromMinutes(2);
                entry.Priority = CacheItemPriority.NeverRemove;
                return Task.FromResult(new List<UserModel>());
            });
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            List<UserModel> users = await GetUsers();
            return users.SingleOrDefault(u => u.Id == id);
        }

        private async void SaveUsers(List<UserModel> users)
        {
            _memoryCache.Set(UsersCacheKey, users, new MemoryCacheEntryOptions
            {
                //SlidingExpiration = TimeSpan.FromMinutes(2)
                Priority = CacheItemPriority.NeverRemove // It's very bad
            });
        }
    }
}
