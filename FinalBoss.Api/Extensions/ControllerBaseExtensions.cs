using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using FinalBoss.Api.Dto;

namespace FinalBoss.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static PagedDto<TReturn> CreatePagedResults<T, TReturn>(
            this ControllerBase controller,
            IMapper mapper,
            IEnumerable<T> enumerable,
            int totalItems,
            int page,
            int pageSize,
            string sort,
            bool ascending) where TReturn : class
        {
            var items = mapper.Map<TReturn[]>(enumerable);

            var mod = totalItems % pageSize;
            var totalPageCount = totalItems / pageSize + (mod == 0 ? 0 : 1);

            var previousUrl = page <= 1
                ? null
                : controller.Url?.Link(null, new
                {
                    paged = true,
                    page = page - 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            var nextUrl = page >= totalPageCount
                ? null
                : controller.Url?.Link(null, new
                {
                    paged = true,
                    page = page + 1,
                    pageSize,
                    sort,
                    ascending
                }).ToLower();

            return new PagedDto<TReturn>
            {
                Items = items,
                PageNumber = page,
                PageSize = items.Length,
                TotalPages = totalPageCount,
                TotalItems = totalItems,
                PreviousUrl = previousUrl,
                NextUrl = nextUrl
            };
        }
    }
}