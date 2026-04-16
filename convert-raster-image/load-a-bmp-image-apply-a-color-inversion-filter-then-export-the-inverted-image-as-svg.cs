using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (RasterImage image = Image.Load(inputPath) as RasterImage)
        {
            if (image == null)
            {
                Console.Error.WriteLine("Failed to load image as RasterImage.");
                return;
            }

            // Invert colors pixel by pixel
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Aspose.Imaging.Color original = image.GetPixel(x, y);
                    Aspose.Imaging.Color inverted = Aspose.Imaging.Color.FromArgb(
                        original.A,
                        255 - original.R,
                        255 - original.G,
                        255 - original.B);
                    image.SetPixel(x, y, inverted);
                }
            }

            // Save the inverted image as SVG
            var svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}