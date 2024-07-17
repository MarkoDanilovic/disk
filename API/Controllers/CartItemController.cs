using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using EntityFrameworkCore.Triggers;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CartItemController : BaseApiController
{
    private readonly ICartItemRepository _cartItemRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IGenericRepository<Track> _trackRepo;
    private readonly IMapper _mapper;

    public CartItemController(ICartItemRepository cartItemRepository, ICartRepository cartRepository, IGenericRepository<Track> trackRepo, IMapper mapper)
    {
        _cartItemRepository = cartItemRepository;
        _cartRepository = cartRepository;
        _trackRepo = trackRepo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<CartItemDto>>> GetCartItems()
    {
        var items = await _cartItemRepository.GetCartItems();
        return Ok(_mapper.Map<IReadOnlyList<CartItem>, IReadOnlyList<CartItemDto>>(items));
        //return Ok(await _cartItemRepository.GetCartItems());
    }
    
    [HttpGet("{cartId}")]
    public async Task<ActionResult<IReadOnlyList<CartItemDto>>> GetCartItemsByCart(int cartId)
    {
        var items = await _cartItemRepository.GetCartItemsByCartId(cartId);
        return Ok(_mapper.Map<IReadOnlyList<CartItem>, IReadOnlyList<CartItemDto>>(items));
        //return Ok(await _cartItemRepository.GetCartItemsByCartId(cartId));
    }

    
    [HttpPost]
    public async Task<ActionResult<CartItem>> CreateCartItem(CartItemDto cartItemDto)
    {
        var cartItem = new CartItem
        {
            Cart = _cartRepository.GetCartById(cartItemDto.CartId).Result,
            Quantity = cartItemDto.Quantity,
            Track = _trackRepo.GetByIdAsync(cartItemDto.TrackId).Result,
            TrackId = cartItemDto.TrackId,
            CartId = cartItemDto.CartId
            
        };
        
        return  _cartItemRepository.CreateCartItemSync(cartItem);
        
        
    }
    
}