using SimApi.Base;
using SimApi.Data;
using SimApi.Schema;

namespace SimApi.Operation;

public interface IDapperAccountService :  IBaseService<Account, AccountRequest, AccountResponse>
{
    ApiResponse<AccountResponse> ByCustomerId(int customerId);
}
