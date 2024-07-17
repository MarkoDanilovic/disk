using Core.Entities;

namespace Core.Interfaces;

public interface ICartRepository
{
    

    Task<Cart> GetCartById(int id);
    
    public Task<Cart> CreateCart(Cart cart);

    public void RemoveCart(int Id);
    public Task<List<Cart>> GetCarts();

    public Task<Cart> UpdateCart(Cart cart);

    public Task<Cart> GetCartByUserId(int id);

    public bool SaveChanges();

}