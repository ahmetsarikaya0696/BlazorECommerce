global using BlazorECommerce.Server.Data;
global using BlazorECommerce.Server.Services.CategoryService;
global using BlazorECommerce.Server.Services.ProductService;
global using BlazorECommerce.Shared;
global using Microsoft.EntityFrameworkCore;
using BlazorECommerce.Server.Services.CartService;

namespace BlazorECommerce
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				string connectionString = builder.Configuration.GetConnectionString("BlazorEcommerce")
							?? throw new Exception("ConnectionString bulunamadý!");

				options.UseSqlServer(connectionString);
			});

			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();

			// Swagger
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			// Adding Services
			builder.Services.AddScoped<IProductService, ProductService>();
			builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartService, CartService>();

            var app = builder.Build();

			app.UseSwaggerUI();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseSwagger();

			app.UseHttpsRedirection();

			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();


			app.MapRazorPages();
			app.MapControllers();
			app.MapFallbackToFile("index.html");

			app.Run();
		}
	}
}