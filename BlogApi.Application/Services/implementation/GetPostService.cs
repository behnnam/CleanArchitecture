using Blog.Api.Command.DtoOut;
using BlogApi.Application.Services.Interfaces;
using BlogApi.Domain.Interfaces;
using BlogApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BlogApi.Application.Services.implementation
{

    public class GetPostService : IGetPostService
    {
        private readonly IGetPostRepository _repository;

        public GetPostService(IGetPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultDto<List<Posts>>> GetAllPostAsync()
        {
            var res = await _repository.GetAllPostAsync();
            if (res == null  || res.Count==0)
            {

                var result = new ResultDto<List<Posts>>(0, "اطلاعات یافت نشد", null);
                return result;
            }
            else
            {
                var result = new ResultDto<List<Posts>>(200, "موفق", res);
                return result;

            }

        }
    }
}
