﻿using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApiShopSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        // POST api/<Orders>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                Order order = _mapper.Map<OrderDto, Order>(orderDto);
                Order newOrder = await _orderService.createNewOrder(order);
                return newOrder != null ? CreatedAtAction(nameof(Get), new { id = orderDto.UserId }, orderDto) :NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // GET api/<Orders>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }

}
