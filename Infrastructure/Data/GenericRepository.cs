using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly StoreContext _context;

    public GenericRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    
    

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public ActionResult<T> GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }


    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<T> UpdateAsync(T t)
    {
        _context.Set<T>().Update(t);
        _context.SaveChanges();
        return await _context.Set<T>().FindAsync(_context.Set<T>().Update(t));
    }

    public void DeleteAsync(int id)
    {
        var t =  _context.Set<T>().FindAsync(id);
        _context.Set<T>().Remove(t.Result);
         _context.SaveChanges();
    }

    public async Task<T> CreateAsync(T t)
    {
        var type =  _context.Set<T>().AddAsync(t);
        _context.SaveChanges();

        return await _context.Set<T>().FindAsync(type.Result);
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
    
    
}