using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Models
{
    public class Posts
    {
        public int Id { get; set; } // شناسه پست
        public string Title { get; set; } // عنوان پست
        public string Content { get; set; } // محتوای پست
        public DateTime CreatedAt { get; set; } // تاریخ ایجاد پست

        // کلید خارجی به کاربر
        public int UserId { get; set; }
        public Users Users { get; set; } // رابطه با کاربر
    }
}
