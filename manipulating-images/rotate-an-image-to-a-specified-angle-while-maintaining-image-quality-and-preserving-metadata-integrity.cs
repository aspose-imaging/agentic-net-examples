using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect: input file path, output file path, rotation angle in degrees
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath> <angle>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        if (!float.TryParse(args[2], out float angle))
        {
            Console.WriteLine("Invalid rotation angle.");
            return;
        }

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Perform rotation only if the image supports arbitrary angle rotation
            if (image is RasterCachedImage rasterImage)
            {
                // Rotate around the center, resize canvas proportionally, fill empty areas with white
                rasterImage.Rotate(angle, true, Color.White);
                // Save preserving original format and metadata
                rasterImage.Save(outputPath);
            }
            else
            {
                Console.WriteLine("The loaded image format does not support arbitrary angle rotation.");
            }
        }
    }
}