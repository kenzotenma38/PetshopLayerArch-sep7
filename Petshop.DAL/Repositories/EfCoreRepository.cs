﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Petshop.DAL.DataContext;
using Petshop.DAL.DataContext.Entities;
using Petshop.DAL.Repositories.Contracts;
using System.Linq.Expressions;

namespace Petshop.DAL.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : Entity
{
    protected readonly AppDbContext DbContext;

    public EfCoreRepository(AppDbContext context)
    {
        DbContext = context;
    }
    
    public virtual async Task CreateAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }
    
    public virtual  async Task DeleteAsync(T entity)
    {
        DbContext.Set<T>().Remove(entity);
        await DbContext.SaveChangesAsync();
    }
 
    public virtual async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool AsNoTracking = false)
    {
        IQueryable<T> query = DbContext.Set<T>();
        if (AsNoTracking)           
            query = query.AsNoTracking();
           
        if (include != null)
            query = include(query);
       
        if (predicate != null)
            query = query.Where(predicate);
      
        if (orderBy != null)
            query = orderBy(query);
        
        return await query.ToListAsync();
    }

    public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool AsNoTracking = false)
    {
        IQueryable<T> query = DbContext.Set<T>();
        if (AsNoTracking)
            query = query.AsNoTracking();
       
        if (include != null)
            query = include(query);
      
        return await query.FirstOrDefaultAsync(predicate);
    }
   
    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbContext.Set<T>().FindAsync(id);
    }
  
    public virtual async Task UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();
    }
}
