using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApiClassLibrary.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<TModel> Sort<TModel>(this IQueryable<TModel> query, string field)
        {
            if (!field.IsNullOrEmpty())
            {
                if (typeof(TModel).GetProperties().Any(x => x.Name.ToLower() == field.ToLower()))
                {
                    var parameter = Expression.Parameter(typeof(TModel), "x");
                    var property = Expression.Property(parameter, field);

                    var o = Expression.Convert(property, typeof(object));
                    var lambda = Expression.Lambda<Func<TModel, object>>(o, parameter);

                    return query.OrderBy(lambda);
                    //return query.OrderBy(x => x.Model)
                }
            }
            return (IOrderedQueryable<TModel>)query;
        }
    }
}
