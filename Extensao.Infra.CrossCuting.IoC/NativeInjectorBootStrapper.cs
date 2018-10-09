using Extensao.Domain.Proposta.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Repositories;
using Extensao.Domain.Proposta.Repositories;
using Extensao.Infra.Data.Transactions;

namespace Extensao.Infra.CrossCuting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<DataContext, DataContext>();
            services.AddScoped<MongoDBDataContext, MongoDBDataContext>();
            services.AddTransient<IUow, Uow>();
            

            #region TipoInscricao
            services.AddTransient<ITipoInscricaoRepository, TipoInscricaoRepository>();
            services.AddTransient<TipoInscricaoCommandHandler, TipoInscricaoCommandHandler>();
            #endregion

            #region TipoAtividade
            services.AddTransient<ITipoAtividadeRepository, TipoAtividadeRepository>();
            #endregion

        }
    }
}
