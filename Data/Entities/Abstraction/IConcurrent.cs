using System.ComponentModel.DataAnnotations;

namespace Data.Entities.Abstraction;

internal interface IConcurrent
{
    public byte[] RowVersion { get; set; }
}