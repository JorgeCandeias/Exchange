using System.ComponentModel.DataAnnotations;

namespace Exchange.Data.SqlServer;

public class SqlServerExchangeRepositoryOptions
{
    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}