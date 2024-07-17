using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class CartRepository : ICartRepository
{
    private readonly StoreContext _context;

    public CartRepository(StoreContext context)
    {
        _context = context;
    }


    

    public async Task<Cart> GetCartById(int id)
    {
        var cart = await _context.Cart.Where(x=> x.Id == id).FirstOrDefaultAsync(u => u.Id == id);
        
        return cart ; 
    }
    
    public async Task<Cart> GetCartByUserId(int id)
    {
        var cart = await _context.Cart.Where(x => x.UserId == id).OrderBy(x => x.OrderDate).LastAsync();
        
        return cart ; 
    }

    public async Task<List<Cart>> GetCarts()
    {
        
        return await _context.Cart.ToListAsync();
    }

    public Task<Cart> UpdateCart(Cart cart)
    {
        cart.Payment = true;
        _context.Update(cart);
        _context.SaveChanges();

        return GetCartById(cart.Id);
    }

    public async Task<Cart> CreateCart(Cart cart)
    {
        if (cart != null)
        { 
            _context.Cart.Add(cart); 
            _context.SaveChanges();
            
            

        }
        
        return cart;
    }

    public void RemoveCart(int Id)
    {
        var cart = _context.Cart.FirstOrDefaultAsync(u => u.Id == Id).Result;
        _context.Cart.Remove(cart);
         
    }
    
    public bool SaveChanges()
    {
        return _context.SaveChanges() > 0;
    }
}