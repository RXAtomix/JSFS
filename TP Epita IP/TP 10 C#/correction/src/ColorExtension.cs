using System;
using System.Drawing;
using System.Collections.Generic;

public static class ColorExtension
{
  public static Color Invert(this Color color)
  {
    int red = 255 - color.R;
    int green = 255 - color.G;
    int blue = 255 - color.B;
    return Color.FromArgb(red, green, blue);
  }

  public static Color Grayscale(this Color color)
  {
    int avg = (21 * color.R + 72 * color.G + 7 * color.B) / 100;
    return Color.FromArgb(avg, avg, avg);
  }

  private static int Restrict256(int n)
  {
    if (n < 0)
      return 0;
    if (n > 255)
      return 255;
    return n;
  }

  private static int Restrict256(double f)
  {
    return Restrict256(Convert.ToInt32(f));
  }

  public static Color Brightness(this Color a, int delta)
  {
    int red = Restrict256(a.R + delta);
    int green = Restrict256(a.G + delta);
    int blue = Restrict256(a.B + delta);
    return Color.FromArgb(red, green, blue);
  }

  public static Color Contrast(this Color color, int delta)
  {
    double factor = (259 * (delta + 255)) / (255.0 * (259.0 - delta));
    int red = Restrict256(factor * (color.R - 128) + 128);
    int green = Restrict256(factor * (color.G - 128) + 128);
    int blue = Restrict256(factor * (color.B - 128) + 128);
    return Color.FromArgb(red, green, blue);
  }

  public static Color GradientMap(this Color color,
                                  Color blackMatch, Color whiteMatch)
  {
    int avg = (color.R + color.G + color.B) / 3;
    color = Color.FromArgb(avg, avg, avg);

    double dyR = (whiteMatch.R - blackMatch.R) / 255.0;
    int red = Convert.ToInt32(color.R * dyR + blackMatch.R);
    double dyG = (whiteMatch.G - blackMatch.G) / 255.0;
    int green = Convert.ToInt32(color.G * dyG + blackMatch.G);
    double dyB = (whiteMatch.B - blackMatch.B) / 255.0;
    int blue = Convert.ToInt32(color.B * dyB + blackMatch.B);

    return Color.FromArgb(red, green, blue);
  }

  public static Color Cover(this Color a, Color b, int opacity = 50)
  {
    if (opacity < 0)
      opacity = 0;
    else if (opacity > 100)
      opacity = 100;

    int red = Restrict256((a.R * (100 - opacity) + b.R * opacity) / 100);
    int green = Restrict256((a.G * (100 - opacity) + b.G * opacity) / 100);
    int blue = Restrict256((a.B * (100 - opacity) + b.B * opacity) / 100);
    return Color.FromArgb(red, green, blue);
  }



  private static double DistanceTo(this Color a, Color b)
  {
    int diffR = b.R - a.R;
    int diffG = b.G - a.G;
    int diffB = b.B - a.B;
    return Math.Sqrt(diffR * diffR + diffG * diffG + diffB * diffB);
  }

  public static Color ClosestIn(this Color color, List<Color> colors)
  {
    if (colors.Count < 1)
      return Color.Empty;
    Color closest = colors[0];
    double smallerDist = color.DistanceTo(closest);

    foreach (Color elt in colors)
    {
      double dist = color.DistanceTo(elt);
      if (dist < smallerDist)
      {
        smallerDist = dist;
        closest = elt;
      }
    }
    return closest;
  }
}
