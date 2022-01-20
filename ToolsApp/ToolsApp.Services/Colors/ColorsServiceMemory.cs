using ToolsApp.Models.Colors;

namespace ToolsApp.Services.Colors
{
  public class ColorsServiceMemory: IColorsService
  {
    private List<Color> _colors = new();

    public IEnumerable<Color> All()
    {
      return _colors;
    }

    public IColorsService Append(NewColor color)
    {
      _colors.Add(
        new(
          _colors.Select(c => c.Id).DefaultIfEmpty(0).Max() + 1,
          color.Name,
          color.Hexcode
        )
      );
      
      return this;
    }

    public IColorsService Remove(int colorId)
    {
      var colorToRemove = _colors.Find(c => c.Id == colorId);

      if (colorToRemove is not null)
      {
        _colors.Remove(colorToRemove);
      }

      return this;
    }

    public IColorsService Replace(Color color)
    {
      int colorIndex = _colors.FindIndex(c => c.Id == color.Id);
      _colors[colorIndex] = color;

      return this;
    }

  }
}
