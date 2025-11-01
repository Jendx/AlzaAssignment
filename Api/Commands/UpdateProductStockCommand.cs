using System.ComponentModel.DataAnnotations;

namespace Api.Commands;

internal sealed record UpdateProductStockCommand(
    [Required] Guid Id,
    [Required] int NewStock);