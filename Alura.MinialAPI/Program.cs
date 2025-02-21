using Alura.MinialAPI.Model;
using Alura.MinialAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Habilitando o swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Instanciando o repositório em memória
var repositorio = new RepositorioDePessoas(true);

app.UseSwagger(); // Ativando o Swagger

// Endpoints da solução
app.MapGet("/", () => "Hello World!");

app.MapGet("/ListarPessoas", () => {
    return repositorio.SelecionarPessoas();
});

app.MapGet("/ListaPessoas/{cpf}", (string cpf) => {
    return repositorio.SelecionarPessoa(cpf);
});

app.MapPost("/ListaPessoas/adicionar", (Pessoa pessoa) => {
    return repositorio.AdicionarPessoas(pessoa);
});

app.MapPut("/ListaPessoas/atualizar", (Pessoa pessoa) => {
    return repositorio.AtualizarPessoas(pessoa);
});

app.MapDelete("/ListaPessoas/remover", (string cpf) => {
    return repositorio.RemoverPessoas(cpf);
});

app.UseSwaggerUI(); // Ativando o Swagger UI

app.Run();
