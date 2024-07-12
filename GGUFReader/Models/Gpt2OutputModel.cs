using Microsoft.ML.Data;

namespace GGUFReader.Models;

public class Gpt2OutputModel
{
    [VectorType(1, 32, 50257)]
    [ColumnName("logits")]
    public float[]? Logits { get; set; }

    [ColumnName("present.0.key")]
    public float[,,,]? Present0Key { get; set; }

    [ColumnName("present.0.value")]
    public float[,,,]? Present0Value { get; set; }

    [ColumnName("present.1.key")]
    public float[,,,]? Present1Key { get; set; }

    [ColumnName("present.1.value")]
    public float[,,,]? Present1Value { get; set; }

    [ColumnName("present.2.key")]
    public float[,,,]? Present2Key { get; set; }

    [ColumnName("present.2.value")]
    public float[,,,]? Present2Value { get; set; }

    [ColumnName("present.3.key")]
    public float[,,,]? Present3Key { get; set; }

    [ColumnName("present.3.value")]
    public float[,,,]? Present3Value { get; set; }

    [ColumnName("present.4.key")]
    public float[,,,]? Present4Key { get; set; }

    [ColumnName("present.4.value")]
    public float[,,,]? Present4Value { get; set; }

    [ColumnName("present.5.key")]
    public float[,,,]? Present5Key { get; set; }

    [ColumnName("present.5.value")]
    public float[,,,]? Present5Value { get; set; }

    [ColumnName("present.6.key")]
    public float[,,,]? Present6Key { get; set; }

    [ColumnName("present.6.value")]
    public float[,,,]? Present6Value { get; set; }

    [ColumnName("present.7.key")]
    public float[,,,]? Present7Key { get; set; }

    [ColumnName("present.7.value")]
    public float[,,,]? Present7Value { get; set; }

    [ColumnName("present.8.key")]
    public float[,,,]? Present8Key { get; set; }

    [ColumnName("present.8.value")]
    public float[,,,]? Present8Value { get; set; }

    [ColumnName("present.9.key")]
    public float[,,,]? Present9Key { get; set; }

    [ColumnName("present.9.value")]
    public float[,,,]? Present9Value { get; set; }

    [ColumnName("present.10.key")]
    public float[,,,]? Present10Key { get; set; }

    [ColumnName("present.10.value")]
    public float[,,,]? Present10Value { get; set; }

    [ColumnName("present.11.key")]
    public float[,,,]? Present11Key { get; set; }

    [ColumnName("present.11.value")]
    public float[,,,]? Present11Value { get; set; }
}
