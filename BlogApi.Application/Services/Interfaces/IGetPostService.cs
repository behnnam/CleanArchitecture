using Blog.Api.Command.DtoOut;
using BlogApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Services.Interfaces
{
    public interface IGetPostService
    {
        Task<ResultDto<List<Posts>>> GetAllPostAsync();
    }
}
