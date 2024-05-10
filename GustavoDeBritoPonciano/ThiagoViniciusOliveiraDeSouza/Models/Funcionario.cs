namespace ThiagoViniciusOliveiraDeSouza.Models;

public class Funcionario{

    public Funcionario(){
    }
    public Funcionario(string cpf, string nome){
        Nome = nome;
        Cpf = cpf;
    }

    public int? Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public Folha? Folha{ get; set;}

}