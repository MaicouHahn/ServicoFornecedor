using ServicoFornecedor.Repositorio.Infra;

namespace ServicoFornecedor.Services.Infra
{
    public static class ServiceExtensionDomain
    {
        public static void ConfigurarDominio(this IServiceCollection services,
                                               IConfiguration configuration)
        {
            services.ConfigurarRepositorio(configuration);
        }
    }
}
