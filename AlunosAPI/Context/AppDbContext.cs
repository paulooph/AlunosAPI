using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(

                new Aluno
                {
                    Id = 1,
                    Nome = "Maria Inês Toledo Leme Ramalho",
                    Email = "proines_ariel@hotmail.com",
                    Idade = 50
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "Geraldo Aparecido Ramalho",
                    Email = "geraldoapramalho@gmail.com",
                    Idade = 53
                }

                );
        }

    }
}
