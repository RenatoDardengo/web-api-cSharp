using Microsoft.EntityFrameworkCore;

namespace web_api.Servicos
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base (options){}
        //Aqui será criada uma tabela alunos. O nome das colunas será as propriedades do modelo (aluno)
        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Fornecedor> Fornecedores { get; set; }

       
        
    }
}