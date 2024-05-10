namespace ThiagoViniciusOliveiraDeSouza.Models;

public class Folha{

    public Folha(){
    }
    public Folha(double valor, double quantidade, int mes, int ano, int funcionarioId){

        Valor = valor;
        Quantidade = quantidade;
        Mes = mes;
        Ano = ano;
        FuncionarioId = funcionarioId;
    }

    // "valor": 50,
    // "quantidade" : 1000,
    // "mes" : 10,
    // "ano" : 2023,
    // "funcionarioId" : 1

    public int? Id { get; set; }
    public int? FuncionarioId { get; set; }
    public int? Ano { get; set; }
    public double? Quantidade { get; set; }
    public double? Valor { get; set; }
    public int? Mes { get; set; }
    public double? SalarioBruto { get; set; }
    public double? ImpostoIrrf { get; set; }
    public double? ImpostoInss { get; set; }
    public double? ImpostoFgts { get; set; }
    public double? SalarioLiquido { get; set; }


}