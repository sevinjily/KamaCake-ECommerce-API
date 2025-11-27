using KamaCake.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace KamaCake.Application.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class,IEntityBase,new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T,bool>>? predicate=null,
            Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null,
            Func<IQueryable<T>,IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking=false);
        //Func<IQueryable<T>,IIncludableQueryable<T,object>>? include=null-bunu yazma sebebimiz include sonra .thenInclude yaza bilek deye
        //Func<IQueryable<T>>? orderBy-yazma sebebimiz her hansi siralama etmek isteye bilerik

        Task<T> GetAsync(Expression<Func<T, bool>> predicate, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, 
            bool enableTracking = false);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);//toList kimi gelmesini istemediyim sorgular ucun

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
