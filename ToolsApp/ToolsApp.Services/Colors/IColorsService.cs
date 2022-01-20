using ToolsApp.Models.Colors;

namespace ToolsApp.Services.Colors
{
  public interface IColorsService
  {
    IEnumerable<Color> All();
    IColorsService Append(NewColor color);
    IColorsService Replace(Color color);
    IColorsService Remove(int colorId);
  }
}
