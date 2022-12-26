using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace web_api
{
    [Table("f_cli_for")]
    public class Fornecedor
    {
        [Key]
        [Column("cod_cfo")]
        public int Id { get; set; }

        [Column("nome_fantasia")]
        [Required]
        
        public string NomeFantasia { get; set; }
        [Column("razao")]
        [Required]
        
        public string RazaoSocial { get; set; }

        [Column("cpf_cnpj")]
        public string Cpf_Cnpj{ get; set; }
        [NotMapped]
        public string CPF { get{return this.Cpf_Cnpj;} set{this.Cpf_Cnpj=value;} }
        [NotMapped]
        public string CNPJ { get { return this.Cpf_Cnpj; } set { this.Cpf_Cnpj = value; } }

      
        [Column("endereco")]
        [Required]

        public string Endereco { get; set; }

    }

}