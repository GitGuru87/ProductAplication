using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeProductData.Models;
using EmployeeProductData.Services;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace EmployeeProductData.Controllers
{
    public class ProductModelsController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductModelsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        // GET: ProductModels
        public async Task<IActionResult> Index()
        {
            using (var connection = GetConnection())
            {
                var products = await connection.QueryAsync<ProductModel>("SELECT * FROM tbl_products");
                return View(products);
            }
        }

        // GET: ProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var connection = GetConnection())
            {
                var productModel = await connection.QueryFirstOrDefaultAsync<ProductModel>(
                    "SELECT * FROM tbl_products WHERE Id = @Id", new { Id = id });

                if (productModel == null)
                {
                    return NotFound();
                }

                return View(productModel);
            }
        }

        // GET: ProductModels/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product,Description,Created")] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                using (var connection = GetConnection())
                {
                    var sql = "INSERT INTO tbl_products (Product, Description, Created) VALUES (@Product, @Description, @Created)";
                    await connection.ExecuteAsync(sql, productModel);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(productModel);
        }

        // GET: ProductModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var connection = GetConnection())
            {
                var productModel = await connection.QueryFirstOrDefaultAsync<ProductModel>(
                    "SELECT * FROM tbl_products WHERE Id = @Id", new { Id = id });

                if (productModel == null)
                {
                    return NotFound();
                }

                return View(productModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Product,Description,Created")] ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (var connection = GetConnection())
                {
                    var sql = "UPDATE tbl_products SET Product = @Product, Description = @Description, Created = @Created WHERE Id = @Id";
                    var affectedRows = await connection.ExecuteAsync(sql, productModel);
                    if (affectedRows == 0)
                    {
                        return NotFound();
                    }

                    return RedirectToAction(nameof(Index));
                }
            }
            return View(productModel);
        }

        // GET: ProductModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var connection = GetConnection())
            {
                var productModel = await connection.QueryFirstOrDefaultAsync<ProductModel>(
                    "SELECT * FROM tbl_products WHERE Id = @Id", new { Id = id });

                if (productModel == null)
                {
                    return NotFound();
                }

                return View(productModel);
            }
        }

        // POST: ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var connection = GetConnection())
            {
                var sql = "DELETE FROM tbl_products WHERE Id = @Id";
                await connection.ExecuteAsync(sql, new { Id = id });
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ProductModelExists(int id)
        {
            using (var connection = GetConnection())
            {
                var productModel = connection.QueryFirstOrDefault<ProductModel>(
                    "SELECT * FROM tbl_products WHERE Id = @Id", new { Id = id });
                return productModel != null;
            }
        }
    }
}
