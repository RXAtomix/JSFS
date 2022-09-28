using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

public static class BitmapExtension
{
  public static void ForEachPixel(this Bitmap image, Func<Color, Color> modify)
  {
    for (int j = 0; j < image.Height; ++j)
      for (int i = 0; i < image.Width; ++i)
        image.SetPixel(i, j, modify(image.GetPixel(i, j)));
  }

  public static void Invert(this Bitmap image)
  {
    image.ForEachPixel(color => color.Invert());
  }

  public static void Grayscale(this Bitmap image)
  {
    image.ForEachPixel(color => color.Grayscale());
  }

  /// @param delta, made to be between -255 and 255, if less, black, if more,
  /// white
  public static void Brightness(this Bitmap image, int delta)
  {
    image.ForEachPixel(color => color.Brightness(delta));
  }

  /// http://www.dfstudios.co.uk/articles/programming/image-programming-algorithms/image-processing-algorithms-part-5-contrast-adjustment/
  /// Increase or decrease the contrast of an image
  /// @param delta, if less than 255, image will be gray
  /// if greater than 511, image will be inverted
  /// between -255 and 255, normal contrast change
  /// betwenn 255 and 511, between very contrasted and inverted
  public static void Contrast(this Bitmap image, int delta)
  {
    image.ForEachPixel(color => color.Contrast(delta));
  }

  public static void GradientMap(this Bitmap image, Color a, Color b)
  {
    image.ForEachPixel(color => color.GradientMap(a, b));
  }

  public static void RotateRight(this Bitmap image)
  {
    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
  }

  public static void RotateLeft(this Bitmap image)
  {
    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
  }

  public static void SymmetryY(this Bitmap image)
  {
    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
  }

  public static void SymmetryX(this Bitmap image)
  {
    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
  }

  /// @param opacity is a percentage
  /// @throws ArgumentExcetion if images don't have the same size
  public static void Cover(this Bitmap a, Bitmap b, int opacity = 50)
  {
    if (a.Size != b.Size)
      throw new ArgumentException("Images must have the same dimensions.");

    if (opacity < 0)
      opacity = 0;
    else if (opacity > 100)
      opacity = 100;

    for (int j = 0; j < a.Height; ++j)
      for (int i = 0; i < a.Width; ++i)
        a.SetPixel(i, j, a.GetPixel(i, j).Cover(b.GetPixel(i, j), opacity));
  }



  public static void Gradient(this Bitmap image, Color left, Color right)
  {
    double dyR = right.R - left.R;
    double dyG = right.G - left.G;
    double dyB = right.B - left.B;

    for (int i = 0; i < image.Width; ++i)
      for (int j = 0; j < image.Height; ++j)
      {
        double x = i / Convert.ToDouble(image.Width);

        int red = Convert.ToInt32(x * dyR + left.R);
        int green = Convert.ToInt32(x * dyG + left.G);
        int blue = Convert.ToInt32(x * dyB + left.B);

        image.SetPixel(i, j, Color.FromArgb(red, green, blue));
      }
  }



  private static List<Color> Palette512()
  {
    List<Color> palette512 = new List<Color>();
    for (double i = 0; i < 256; i += (255 / 7.0))
      for (double j = 0; j < 256; j += (255 / 7.0))
        for (double k = 0; k < 256; k += (255 / 7.0))
        {
          int red = Convert.ToInt32(i);
          int green = Convert.ToInt32(j);
          int blue = Convert.ToInt32(k);
          palette512.Add(Color.FromArgb(red, green, blue));
        }
    return palette512;
  }

  // Retourne la couleur la plus fréquente, alignée du 256 couleurs (pour que
  // les pixels de couelurs similaire soeint regroupés dans le compte).
  // A voir peut-être : - Taille de bucket différente (aka pas de 256 couleurs)?
  // - Les x couleurs les plus fréquentes au lieu de la plus fréquente (+ gérer
  // les cas où on aurait pas x couleurs différentes) ?
  // - Gestion de l'alpha ?
  private static List<Color> MostFrequentColors(this Bitmap image, int n)
  {
    List <Color> palette512 = Palette512();
    // Dictionnaire associant les couleurs présentes et leur fréquence
    // d'apparaition
    Dictionary<Color, int> colors = new Dictionary<Color, int>();
    for (int j = 0; j < image.Height; ++j)
      for (int i = 0; i < image.Width; ++i)
      {
        Color pix = image.GetPixel(i, j);
        // Ajuste la couleur à celle la plus proche en 512 couleurs
        pix = pix.ClosestIn(palette512);
        if (colors.ContainsKey(pix))
          colors[pix] += 1;
        else
          colors.Add(pix, 1);
      }

    if (colors.Count < n)
      n = colors.Count;

    return colors.OrderByDescending(x => x.Value)
                 .ToDictionary(x => x.Key, x => x.Value)
                 .Keys.ToList<Color>().GetRange(0, n);
  }

  private static void DrawColors(this Bitmap image, List<Color> colors)
  {
    for (int i = 0; i < image.Width; ++i)
      for (int j = 0; j < image.Height; ++j)
      {
        int index = Convert.ToInt32(
          Math.Truncate(((i / Convert.ToDouble(image.Width)) * colors.Count)));
        image.SetPixel(i, j, colors[index]);
      }
  }

  public static void Palette(this Bitmap image, int n)
  {
    image.DrawColors(image.MostFrequentColors(n));
  }
}
