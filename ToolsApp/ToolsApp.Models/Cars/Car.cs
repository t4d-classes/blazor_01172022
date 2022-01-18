namespace ToolsApp.Models.Cars
{
  public record Car (
    int Id,
    string Make,
    string Model,
    int Year,
    string Color,
    decimal Price
  );
}
