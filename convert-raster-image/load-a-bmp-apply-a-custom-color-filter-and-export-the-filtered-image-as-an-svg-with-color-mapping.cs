using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (BmpImage bmp = new BmpImage(inputPath))
        {
            // Apply a custom color filter:
            // Example: replace pure red pixels with pure blue
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    if (pixel.R == 255 && pixel.G == 0 && pixel.B == 0)
                    {
                        // Change red to blue while preserving alpha
                        bmp.SetPixel(x, y, Color.FromArgb(pixel.A, 0, 0, 255));
                    }
                }
            }

            // Save the filtered image as SVG with default options
            var svgOptions = new SvgOptions();
            bmp.Save(outputPath, svgOptions);
        }
    }
}