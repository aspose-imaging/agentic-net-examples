using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired background color (opaque)
        // Example: solid magenta
        Color backgroundColor = Color.FromArgb(255, 255, 0, 255);

        // Load the PNG image
        using (PngImage pngImage = new PngImage(inputPath))
        {
            // Iterate over all pixels and replace fully transparent ones with the background color
            for (int y = 0; y < pngImage.Height; y++)
            {
                for (int x = 0; x < pngImage.Width; x++)
                {
                    Color pixel = pngImage.GetPixel(x, y);
                    if (pixel.A == 0) // fully transparent
                    {
                        pngImage.SetPixel(x, y, backgroundColor);
                    }
                }
            }

            // Save the modified image, preserving PNG encoding
            pngImage.Save(outputPath);
        }
    }
}