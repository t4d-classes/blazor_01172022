using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsApp.Models.Colors;

namespace ToolsApp.Services.Colors
{
  public class ColorToolStoreService
  {
    private IColorsService _colorsService;

    public ColorToolStoreService(IColorsService colorsService)
    {
      _colorsService = colorsService;
    }

    public IEnumerable<Color> Colors
    {
      get
      {
        return _colorsService.All();
      }
    }

    public ColorToolStoreService AddColor(NewColor color)
    {
      _colorsService.Append(color);
      return this;
    }

    public ColorToolStoreService DeleteColor(int colorId)
    {
      _colorsService.Remove(colorId);
      return this;
    }
  }
}
