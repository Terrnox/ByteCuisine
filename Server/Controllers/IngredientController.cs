﻿using ByteCuisine.Server.Controllers.Data;
using ByteCuisine.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ByteCuisine.Server.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private readonly DataContext _dataContext;


        public IngredientController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddDish([FromBody] IngredientDTO model)
        {
            try
            {
                var newIngredient = new Ingredient
                {
                    Name = model.Name,
                    Description = model.Description,
                    Image = model.Image,
                    Category = model.Category,
                    Callories = model.Callories,
                };
                _dataContext.Ingredients.Add(newIngredient);
                await _dataContext.SaveChangesAsync();
                return Ok(newIngredient);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<Ingredient>>> Get()
        {
            try
            {
                var list = await _dataContext.Ingredients.ToListAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}