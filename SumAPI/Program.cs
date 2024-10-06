var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint GET /sum para calcular a soma
app.MapGet("/sum", (string? a, string? b) =>
{
    // Tentar converter os parâmetros a e b para números
    if (!double.TryParse(a, out double numberA))
    {
        return Results.BadRequest(new { error = "O parâmetro 'a' não é um número válido." });
    }

    if (!double.TryParse(b, out double numberB))
    {
        return Results.BadRequest(new { error = "O parâmetro 'b' não é um número válido." });
    }

    // Calcular a soma
    double result = numberA + numberB;

    // Retornar o resultado em JSON
    return Results.Ok(new { result });
});

// Inicializar a aplicação
app.Run();
