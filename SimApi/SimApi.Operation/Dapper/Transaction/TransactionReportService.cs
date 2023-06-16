﻿using AutoMapper;
using Castle.Core.Resource;
using Serilog;
using SimApi.Base;
using SimApi.Data;
using SimApi.Data.Uow;
using SimApi.Schema;

namespace SimApi.Operation;

public class TransactionReportService : ITransactionReportService
{

    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public TransactionReportService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public ApiResponse<List<TransactionViewResponse>> GetAll()
    {
        try
        {
            var entityList = unitOfWork.Repository<TransactionView>().GetAll();
            var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>(entityList);
            return new ApiResponse<List<TransactionViewResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
        }
    }
    

    public ApiResponse<List<TransactionViewResponse>> GetByAccountId(int accountId)
    {
        try
        {
            var entityList = unitOfWork.Repository<TransactionView>().Where(e => e.AccountId==accountId);
            var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>((List<TransactionView>)entityList);
            return new ApiResponse<List<TransactionViewResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
        }
    }

    public ApiResponse<List<TransactionViewResponse>> GetByCustomerId(int customerId)
    {
        try
        {
            var entityList = unitOfWork.Repository<TransactionView>().Where(e => e.CustomerId == customerId);
            var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>((List<TransactionView>)entityList);
            return new ApiResponse<List<TransactionViewResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
        }
    }

    public ApiResponse<TransactionViewResponse> GetById(int id)
    {
        try
        {
            var entityList = unitOfWork.Repository<TransactionView>().GetById(id);
            var mapped = mapper.Map<TransactionView, TransactionViewResponse>(entityList);
            return new ApiResponse<TransactionViewResponse>(mapped);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "GetAll Exception");
            return new ApiResponse<TransactionViewResponse>(ex.Message);
        }
    }

    public ApiResponse<List<TransactionViewResponse>> GetByReferenceNumber(string referenceNumber)
    {

        try
        {
            var entityList = unitOfWork.Repository<TransactionView>().Where(e => e.ReferenceNumber == referenceNumber);
            var mapped = mapper.Map<List<TransactionView>, List<TransactionViewResponse>>((List<TransactionView>)entityList);
            return new ApiResponse<List<TransactionViewResponse>>(mapped);
        }
        catch (Exception ex)
        {
            return new ApiResponse<List<TransactionViewResponse>>(ex.Message);
        }
    }
}
