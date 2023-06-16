using Microsoft.AspNetCore.Mvc;
using SimApi.Base;
using SimApi.Operation;
using SimApi.Operation.Category;
using SimApi.Schema;

namespace SimApi.Service;


[EnableMiddlewareLogger]
[ResponseGuid]
[Route("simapi/v1/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        this.categoryService = categoryService;
    }

    [HttpGet]
    public ApiResponse<List<CategoryResponse>> GetAll()
    {
        var customerList = categoryService.GetAll();
        return customerList;
    }

    [HttpGet("{id}")]
    public ApiResponse<CategoryResponse> GetById(int id)
    {
        var customer = categoryService.GetById(id);
        return customer;
    }

    [HttpPost]
    public ApiResponse Post([FromBody] CategoryRequest request)
    {
        return categoryService.Insert(request);
    }

    [HttpPut("{id}")]
    public ApiResponse Put(int id, [FromBody] CategoryRequest request)
    {
        return categoryService.Update(id, request);
    }

    [HttpDelete("{id}")]
    public ApiResponse Delete(int id)
    {
        return categoryService.Delete(id);
    }
}
