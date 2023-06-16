using AutoMapper;
using Serilog;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Uow;
using SimApi.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SimApi.Operation.Category
{
    public class CategoryService :ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        

        public ApiResponse Delete(int Id)
        {
            unitOfWork.DapperRepository<SimApi.Data.Category>().DeleteById(Id);
            unitOfWork.Complete();
            return new ApiResponse();
        }

        public ApiResponse<List<CategoryResponse>> GetAll()
        {
            var entity=unitOfWork.DapperRepository<SimApi.Data.Category>().GetAll();
            unitOfWork.Complete();
            var mapped = mapper.Map<List<SimApi.Data.Category>, List<CategoryResponse>>(entity);
            return new ApiResponse<List<CategoryResponse>>(mapped);
        }

        public ApiResponse<CategoryResponse> GetById(int id)
        {
            var entity = unitOfWork.DapperRepository<SimApi.Data.Category>().GetById(id);
            unitOfWork.Complete();
            var mapped = mapper.Map<SimApi.Data.Category, CategoryResponse>(entity);
            return new ApiResponse<CategoryResponse>(mapped);
        }

        public ApiResponse Insert(CategoryRequest request)
        {
            var entity = mapper.Map<CategoryRequest, SimApi.Data.Category>(request);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = "sim@sim.com";

            unitOfWork.DapperRepository<SimApi.Data.Category>().Insert(entity);
            unitOfWork.Complete();
            return new ApiResponse();
        }

        public ApiResponse Update(int Id, CategoryRequest request)
        {
            var entity = mapper.Map<CategoryRequest, SimApi.Data.Category>(request);

            entity.Id = Id;
            entity.UpdatedAt = DateTime.UtcNow;

            unitOfWork.DapperRepository<SimApi.Data.Category>().Update(entity);
            unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
