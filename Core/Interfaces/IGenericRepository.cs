using Core.Entities;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T: BaseEntity
{
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAllAsync();

    ActionResult<T> GetById(int id);

    Task<T> GetEntityWithSpec(ISpecification<T> spec);

    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

    Task<T> UpdateAsync(T t);

    void DeleteAsync(int id);

    Task<T> CreateAsync(T t);

    Task<int> CountAsync(ISpecification<T> spec);

    public bool SaveChanges();
}