using GGUFReader.Services;
using LLama.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ML;

namespace GGUFReader.Utils;

public static class DIManager
{
    public static IServiceCollection AddMiLibreria(this IServiceCollection services)
    {
        services.AddSingleton<MLContext>();

        services.AddScoped<IInferenceParamsService, InferenceParamsService>();
        services.AddScoped<ILlamaModelService, LlamaModelService>();

        return services;
    }
}
