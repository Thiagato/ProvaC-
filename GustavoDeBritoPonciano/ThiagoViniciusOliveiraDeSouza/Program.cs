using Microsoft.AspNetCore.Mvc;
using ThiagoViniciusOliveiraDeSouza.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Db>();
var app = builder.Build();




// POST	api/funcionario/cadastrar
app.MapPost("/api/funcionario/cadastrar", ([FromBody] Funcionario func, [FromServices] Db db) => {

    db.Funcionario.Add(func);
    db.SaveChanges();
    return Results.Created();

});

// GET	api/funcionario/listar
app.MapGet("/api/funcionario/listar", ([FromServices] Db db) => {
    
    return Results.Ok(db.Funcionario.ToList());


});

// POST	api/folha/cadastrar
app.MapPost("/api/folha/cadastrar", ([FromBody] Folha folha, [FromServices] Db db) => {


    
    folha.SalarioBruto = folha.Quantidade * folha.Valor;
    if(folha.SalarioBruto >= 1903.99 && folha.SalarioBruto <= 2826.65){
             folha.ImpostoIrrf = folha.SalarioBruto * 0.925 -  folha.SalarioBruto;
        }else if(folha.SalarioBruto >= 2826.65 && folha.SalarioBruto <= 3751.05){
            folha.ImpostoIrrf = folha.SalarioBruto * 0.85 -  folha.SalarioBruto;
        }else if(folha.SalarioBruto >= 3751.05 && folha.SalarioBruto <= 4664.68){
            folha.ImpostoIrrf = folha.SalarioBruto * 0.775 -  folha.SalarioBruto;
        }else if(folha.SalarioBruto >= 4664.68){
            folha.ImpostoIrrf = folha.SalarioBruto * 0.725 -  folha.SalarioBruto;
        }
       
        if(folha.SalarioBruto <= 1693.72){
            folha.ImpostoInss = folha.SalarioBruto * 0.92;
        }
        else if(folha.SalarioBruto >= 1693.73 && folha.SalarioBruto <= 2822.90){
             folha.ImpostoInss = folha.SalarioBruto * 0.91 -  folha.SalarioBruto;
        }else if(folha.SalarioBruto >= 2822.91 && folha.SalarioBruto <= 5645.80){
            folha.ImpostoInss = folha.SalarioBruto * 0.89 -  folha.SalarioBruto;
        }else if(folha.SalarioBruto >= 5645.81){
            folha.ImpostoInss = folha.SalarioBruto - 621.03 -  folha.SalarioBruto;
        }
         folha.ImpostoFgts = folha.SalarioBruto * 0.92 -  folha.SalarioBruto;
        
        folha.SalarioLiquido = folha.SalarioBruto +  folha.ImpostoIrrf + folha.ImpostoInss;

        Funcionario? fun = db.Funcionario.Find(folha.FuncionarioId);
    
    
        if(fun is  null){
            return Results.NotFound("nao acheit");
        }
        fun.Folha = folha;
        db.Update(fun);
        db.SaveChanges();
        return Results.Ok("MUDOU!!");

});

// GET	api/folha/listar
app.MapGet("/api/folha/listar", ( [FromServices] Db db) => {
     List<Funcionario> fu = new List<Funcionario>();
    foreach (Funcionario f in db.Funcionario.ToList())
    {
        if(f.Id == f.Folha.FuncionarioId){
           f.Folha = f.Folha;
            fu.Add(f);
        }
    }
    

    return Results.Ok(fu);
});

// GET	api/folha/buscar/{cpf}/{mes}/{ano}
// app.MapGet("/api/folha/buscar/{cpf}/{mes}/{ano}", (string cpf, int mes, int ano) => {
    
//      foreach (Funcionario f in funca)
//     {
//         if(f.Cpf == cpf && f.Folha.Mes == mes && f.Folha.Ano == ano){
//             return Results.Ok(f);
//         }
//     }
//     return Results.NotFound("nao acheit");

// });






app.Run();
