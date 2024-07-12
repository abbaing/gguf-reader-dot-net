namespace GGUFReader.Models;

public struct GGUFModel(ModelType model)
{
    public ModelType Model { get; set; } = model;

    public readonly override string ToString() => Model.ToString();
}
