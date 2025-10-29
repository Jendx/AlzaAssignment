using System.ComponentModel.DataAnnotations;

namespace Api.Commands;

internal sealed record UpdateProductStockCommand(
    [Required] string Id,
    [Required] int NewStock);