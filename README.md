# GGUF Reader .NET

GGUF Reader .NET facilitates reading GGUF files from different LLMs in .NET Core 8. It includes features for dynamic DLL loading, GGUF file interpretation, and interactive prompt execution for advanced operations.

## Features

- Dynamic DLL loading
- GGUF file interpretation
- Interactive prompt execution

## Getting Started

### Libraries

- .NET Core 8 SDK
- NUnit

### Installation

To include GGUF Reader .NET in your project, add the following dependency injection setup in your `Startup.cs` or wherever you configure services in your .NET Core application:

```csharp
public static void Load(IServiceCollection services)
{
    ...

    GGUFReader.Utils.DIManager.Load(services);

    ...
}
```

# Usage

To use the GGUF Reader .NET in your project, follow these steps:

1. Add the necessary using directives:

    ```csharp
    using GGUFReader.Factories;
    using GGUFReader.Services;
    ```

2. Implement the GGUF business logic in your class. Here’s an example of how to use the `ILlamaModelServiceFactory` to interact with GGUF files:

    ```csharp
    namespace My.Powerful.Project.BusinessLayer
    {
        public class GGUFBusinessLayer(ILlamaModelServiceFactory llamaModelServiceFactory) : IGGUFBusinessLayer
        {
            ...

            public async Task<string> Ask(string folderPath, string modelName, string prompt)
            {
                ILlamaModelService llamaDataLayer = llamaModelServiceFactory.Create(folderPath, modelName);
                return await llamaDataLayer.GenerateResponseAsync(prompt);
            }
        }
    }
    ```

## Issues

If you encounter any issues or have questions, please open an issue in the repository or contact us directly.

## Author

Abba David, Eng.