using e_commerce.Entity;
using e_commerce.Model;
using e_commerce.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace e_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IProduct product, IWebHostEnvironment webHostEnvironment)
        {
            _product = product;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
           
            var resp=await _product.GetAllProducts();
            if(resp.Any())
                
            return Ok(resp);
            else
                return NotFound("No Record Found");
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetSingleProduct(int id)
        {
            ///<summary>
            ///gets a list of all products
            ///</summary>
            ///<returns>A list of products</returns>
            if (id <= 0)
                return BadRequest("Invalid ID");
            var resp = await _product.GetSingleProduct(id);
            if (resp != null)
                return Ok(resp);
            else
                return NotFound("No record Found");
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductRequest product)
        {
            //if(productEntity.Id>0)
            //    return BadRequest("Id is AutoIncremented kindly use 0");
            if (product.Name.IsNullOrEmpty())
                return BadRequest("Product Name is Required");
            if (product.Description.IsNullOrEmpty())
                return BadRequest("Product Description is Required");
            if (product.Price<=0)
                return BadRequest("Invalid Product Price");
            var resp = await _product.CreateProduct(product);
            if(resp>0)

            return Ok("Save Successfully with id="+resp);
            else 
                return BadRequest("Bad request");
        }
        [HttpGet("GetImagesURL")]
        public IActionResult GetImagesURL()
        {
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
            var provider= new PhysicalFileProvider(folderPath);
            var contect = provider.GetDirectoryContents(string.Empty);
            var imageurl = contect.Where(file => !file.IsDirectory).Select(file => $"{Request.Scheme}://{Request.Host}/images/products/{file.Name}").ToList();
            return Ok(imageurl);
        }

    }
}
