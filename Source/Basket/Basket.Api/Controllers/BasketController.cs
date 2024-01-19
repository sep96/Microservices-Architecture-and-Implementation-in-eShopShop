using Basket.Api.Entities;
using Basket.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
        }
        /// <summary>
        /// for Getting SoppingCart
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("{userName}" , Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart) , (int) HttpStatusCode.OK)]
        public virtual async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
                => Ok((await _basketRepository.GetBasketAsync(userName)) ?? new ShoppingCart(userName));
        /// <summary>
        /// for Updating 
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
         => Ok(await _basketRepository.UpdateBasketAsync(basket));


        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public virtual async Task<ActionResult> DeleteBasket(string userName)
        {
           await _basketRepository.DeleteBasketAsync(userName);
            return Ok();

        }


    }
}
