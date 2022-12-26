using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    [Table("tbl_alunos")]
    public class Aluno
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome", TypeName ="varchar")]
        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Column("matricula", TypeName = "varchar")]
        [Required]
        [MaxLength(8)]
        public string Matricula { get; set; }
        [Column("notas", TypeName = "text")]
        public string Notas { get; set; }
    }

}