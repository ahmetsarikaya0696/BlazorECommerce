﻿using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
		{
			var response = await _categoryService.GetCategoriesAsync();
			return Ok(response);
		}
	}
}
