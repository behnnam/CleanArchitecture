using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Models
{
    public class Users
    {
        public int Id { get; set; } // شناسه کاربر
        public string Username { get; set; } // نام کاربری
        public string Email { get; set; } // ایمیل کاربر
        public string PasswordHash { get; set; } // هش رمز عبور

        // رابطه یک به چند با پست‌ها
        public ICollection<Posts> Posts { get; set; }
    }
}
