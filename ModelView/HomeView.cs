namespace web_api;

public record HomeView
{
    //public string mensagem{get{ return "Bem vindo ao sistema - versão 1.0";}}
    public string mensagem => "Bem vindo ao sistema - versão 1.0";

    public List<dynamic> Endpoints => new List<dynamic>(){
        new {item = new{
            Documentacao = "/swagger"}
        },
        new {item=new{
            Path = "/alunos"
        }}

    };

}
