using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;



public class CartController : BaseApiController
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _usersRepository;
    private readonly ICartItemRepository _cartItemRepository;
    private readonly IGenericRepository<Track> _trackRepository;

    public CartController(ICartRepository cartRepository, IMapper mapper, IUserRepository usersRepository, ICartItemRepository cartItemRepository, 
        IGenericRepository<Track> trackRepository)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
        _usersRepository = usersRepository;
        _cartItemRepository = cartItemRepository;
        _trackRepository = trackRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> GetCartById(int id)
    {
        var cart = await _cartRepository.GetCartById(id);
        //return _mapper.Map<Cart, CartDto>(cart);
        return cart;
    }
    
    
    [HttpGet()]
    public async Task<ActionResult<IReadOnlyList<Cart>>> GetCarts()
    {
        var cart = await _cartRepository.GetCarts();
        //return _mapper.Map<Cart, CartDto>(cart);
        return cart;
    }
    
    [HttpPost]
    public async Task<ActionResult<Cart>> CreateCart(CartDto cartDto)
    {

        decimal subtotal = 0;
        foreach (var item in cartDto.CartItems)
        {

            
            
            var track = _trackRepository.GetByIdAsync(item.TrackId);
            if (track.Result.Quantity < item.Quantity)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Product is out of stock");
            }
            subtotal += (track.Result.Price*item.Quantity);
        }

        try
        {
            var cart = _mapper.Map<Cart>(cartDto);
            cart.Subtotal = subtotal;

            

            

            return Ok(await _cartRepository.CreateCart(cart));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCart(int id)
    {
        try
        {
            if (id != null)
            {
                _cartRepository.RemoveCart(id);
                _cartRepository.SaveChanges();
                return Ok();
            }

            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}