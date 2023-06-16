using SimApi.Base;
using SimApi.Data;
using SimApi.Schema;

namespace SimApi.Operation.Category
{
    public interface ICategoryService : IBaseService<SimApi.Data.Category, CategoryRequest, CategoryResponse>
    {
    }
}
