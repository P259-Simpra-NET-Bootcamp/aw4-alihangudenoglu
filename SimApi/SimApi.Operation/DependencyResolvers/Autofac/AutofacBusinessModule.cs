using Autofac;
using Autofac.Core;
using SimApi.Data.Uow;
using SimApi.Operation.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLogService>().As<IUserLogService>().SingleInstance();
            builder.RegisterType<TokenService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<AccountService>().As<IAccountService>().SingleInstance();
            builder.RegisterType<TransactionService>().As<ITransactionService>().SingleInstance();
            builder.RegisterType<TransactionReportService>().As<ITransactionReportService>().SingleInstance();
            builder.RegisterType<DapperAccountService>().As<IDapperAccountService>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
        }
    }
}
