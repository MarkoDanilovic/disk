using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Core.Interfaces;

public interface ICartItemRepository
{
    Task<IReadOnlyList<CartItem>> GetCartItems();
    Task<IReadOnlyList<CartItem>> GetCartItemsByCartId(int id);
    Task<CartItem> CreateCartItem(CartItem cartItem);

    public ActionResult<CartItem> CreateCartItemSync(CartItem cartItem);

    public bool SaveChanges();
}