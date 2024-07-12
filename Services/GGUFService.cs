using GGUFReader.Utils;
using LLama;
using LLama.Common;

namespace GGUFReader.Services
{
    public class GGUFService(string folderPath, string modelName, float temperature = 0.7f)
    {
        private const string MODEL_PATH = "Models/GGUF";

        private readonly string folderPath = folderPath;
        private readonly string modelName = modelName;
        private readonly float temperature = temperature;

        public async Task<string> GenerateResponse(string prompt)
        {
            string modelPath = PathManager.GetModelPath(MODEL_PATH, folderPath, modelName);

            ModelParams modelParams = new(modelPath);
            using LLamaWeights weights = LLamaWeights.LoadFromFile(modelParams);

            using LLamaContext context = weights.CreateContext(modelParams);
            InteractiveExecutor executor = new(context);

            InferenceParams inferenceParams = new()
            {
                Temperature = temperature,
                MaxTokens = 128,
                Mirostat = MirostatType.Mirostat2,
                MirostatTau = 10,
            };

            return await StringManager.AsyncAppend(executor.InferAsync(prompt, inferenceParams));
        }
    }
}
