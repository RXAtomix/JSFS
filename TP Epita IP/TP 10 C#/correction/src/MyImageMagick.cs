using System;
using System.Drawing;

public class MyImageMagick
{
  public static void Main(string[] args)
  {
    if (args.Length < 3)
    {
      Console.WriteLine("Usage: ./MyImageMagick.Exe source-image {options} destination-image");
      Console.WriteLine("Options");
      Console.WriteLine("-b, --brightness VALUE");
      Console.WriteLine("-c, --contrast VALUE");
      Console.WriteLine("-m, --cover PATH OPACITY");
      Console.WriteLine("-d, --gradient COLOR COLOR");
      Console.WriteLine("-a, --gradient-map COLOR COLOR");
      Console.WriteLine("-g, --grayscale");
      Console.WriteLine("-i, --invert");
      Console.WriteLine("-p, --palette NUMBER");
      Console.WriteLine("-l, --rotate-left");
      Console.WriteLine("-r, --rotate-right");
      Console.WriteLine("-x, --symmetry-x");
      Console.WriteLine("-y, --symmetry-y");
      return;
    }
    Bitmap image;
    try
    {
      image = new Bitmap(args[0]);
    }
    catch (Exception)
    {
      Console.Error.WriteLine("Cannot open the source image, aborting.");
      return;
    }
    int i = 1;
    try
    {
      for (; i < args.Length - 1; i++)
      {
        RunTreatment(args, ref i, image);
      }
    }
    catch (ArgumentException)
    {
      Console.Error.WriteLine("Invalid argument near token '" + args[i]
                                + "'. Aborting.");
      return;
    }
    try
    {
      image.Save(args[args.Length - 1]);
    }
    catch
    {
      Console.Error.WriteLine("Error while saving the output image.");
    }
  }

  public static void RunTreatment(string[] args, ref int i, Bitmap image)
  {
    int j = 0;
    switch(args[i])
    {
      case "--grayscale": case "-g":
        image.Grayscale();
        break;
      case "--invert": case "-i":
        image.Invert();
        break;
      case "--brightness": case "-b":
        if (i == args.Length - 2 || !Int32.TryParse(args[++i], out j))
          throw new ArgumentException("Missing or invalid argument for brightness.");
        image.Brightness(j);
        break;
      case "--cover": case "-m":
        if (i >= args.Length - 3 || !Int32.TryParse(args[i + 2], out j))
          throw new ArgumentException("Missing or invalid arguments for cover.");
        Bitmap mixed;
        try
        {
          mixed = new Bitmap(args[++i]);
          image.Cover(mixed, j);
        }
        catch (Exception e)
        {
          throw new ArgumentException(e.Message);
        }
        finally
        {
          i++;
        }
        break;
      case "--contrast": case "-c":
        if (i == args.Length - 2 || !Int32.TryParse(args[++i], out j))
          throw new ArgumentException("Missing or invalid argument for contrast.");
        image.Contrast(j);
        break;
      case "--gradient-map": case "-a":
        image.GradientMap(Color.FromName(args[++i]), Color.FromName(args[++i]));
        break;
      case "--gradient": case "-d":
        image.Gradient(Color.FromName(args[++i]), Color.FromName(args[++i]));
        break;
      case "--palette": case "-p":
        if (i == args.Length - 2 || !Int32.TryParse(args[++i], out j))
          throw new ArgumentException("Missing or invalid argument for palette.");
        image.Palette(j);
        break;
      case "--rotate-right": case "-r":
        image.RotateRight();
        break;
      case "--rotate-left": case "-l":
        image.RotateLeft();
        break;
      case "--symmetry-x": case "-x":
        image.SymmetryX();
        break;
      case "--symmetry-y": case "-y":
        image.SymmetryY();
        break;
      default:
        throw new ArgumentException("Unrecognized option '" + args[i] + "'.");
    }
  }

}
