using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <program> <inputPath> <outputPath> <angle>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        if (!float.TryParse(args[2], out float angle))
        {
            Console.WriteLine("Invalid rotation angle.");
            return;
        }

        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            if (!image.IsCached)
                image.CacheData();

            image.Rotate(angle, false, Color.Black);
            image.Save(outputPath);
        }
    }
}