using Microsoft.ML.Data;

namespace GGUFReader.Models;

public class Gpt2InputModel
{
    [VectorType(1, 32)]
    [ColumnName("input_ids")]
    public required long[] InputIds { get; set; }

    [VectorType(1, 32)]
    [ColumnName("attention_mask")]
    public required long[] AttentionMask { get; set; }
}
