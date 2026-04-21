using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source raster image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PNG save options with Truecolor with Alpha (transparent background)
                PngOptions pngOptions = new PngOptions
                {
                    ColorType = Aspose.Imaging.FileFormats.Png.PngColorType.TruecolorWithAlpha,
                    BitDepth = 8,               // 8 bits per channel
                    CompressionLevel = 9,       // Maximum compression
                    Progressive = true          // Enable progressive loading
                };

                // Save the image as PNG using the configured options
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}