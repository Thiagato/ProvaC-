using Microsoft.EntityFrameworkCore;
namespace ThiagoViniciusOliveiraDeSouza.Models;

public class Db : DbContext
{
    public DbSet<Funcionario> Funcionario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Gustavo_Thiago.db");
    }
}