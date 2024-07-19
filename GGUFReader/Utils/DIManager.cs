using GGUFReader.Factories;
using GGUFReader.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;

namespace GGUFReader.Utils;

public static class DIManager
{
    public static IServiceCollection Load(this IServiceCollection services)
    {
        services.AddSingleton<MLContext>();

        services.AddSingleton<ILLamaModelExecutorFactory, LLamaModelExecutorFactory>();

        services.AddSingleton<IInferenceParamsService, InferenceParamsService>();

        return services;
    }
}
