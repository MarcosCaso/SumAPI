var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Endpoint GET /sum para calcular a soma
app.MapGet("/sum", (string? a, string? b) =>
{
    // Tentar converter os par�metros a e b para n�meros
    if (!double.TryParse(a, out double numberA))
    {
        return Results.BadRequest(new { error = "O par�metro 'a' n�o � um n�mero v�lido." });
    }

    if (!double.TryParse(b, out double numberB))
    {
        return Results.BadRequest(new { error = "O par�metro 'b' n�o � um n�mero v�lido." });
    }

    // Calcular a soma
    double result = numberA + numberB;

    // Retornar o resultado em JSON
    return Results.Ok(new { result });
});

// Inicializar a aplica��o
app.Run();
