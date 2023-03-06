using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Scanner.Data;
using Product.Scanner.DTOs;
using Product.Scanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Scanner.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _context.Products.ToList();
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ProductModel, ProductDTO>();
                });
                var mapper = new Mapper(config);
                return Ok(new { status = "success", data = mapper.Map<List<ProductDTO>>(products)});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDTO dto)
        {
            try
            {
                dto.QRCode = Guid.NewGuid().ToString(); 
                dto.CreatedAt = DateTime.Now;
                dto.UpdatedAt = DateTime.Now;

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ProductDTO, ProductModel>().ReverseMap();
                });

                var mapper = new Mapper(config);

                var dbObj = mapper.Map<ProductModel>(dto);

                var obj = _context.Products.Add(dbObj);
                
                if(_context.SaveChanges() > 0 && obj != null)
                {
                    var retDTO = mapper.Map<ProductDTO>(obj.Entity);
                    return Ok(retDTO);
                }

                throw new Exception("Unable to save changes");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
