using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load BMP image
            using (RasterImage bmpImage = Image.Load(inputPath) as RasterImage)
            {
                if (bmpImage == null)
                {
                    Console.Error.WriteLine("Failed to load BMP image.");
                    return;
                }

                // Apply a simple color filter: swap Red and Blue channels
                for (int y = 0; y < bmpImage.Height; y++)
                {
                    for (int x = 0; x < bmpImage.Width; x++)
                    {
                        Color original = bmpImage.GetPixel(x, y);
                        Color transformed = Color.FromArgb(original.A, original.B, original.G, original.R);
                        bmpImage.SetPixel(x, y, transformed);
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the filtered image as SVG with default options
                var svgOptions = new SvgOptions();
                bmpImage.Save(outputPath, svgOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}