using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths (preserve original filename)
        string inputPath = @"C:\Templates\sample.png";
        string outputPath = inputPath; // same location and filename

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage image = new PngImage(inputPath))
            {
                // Apply a simple filter – convert to grayscale
                image.Grayscale();

                // Prepare PNG save options (example: adaptive filter)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive,
                    // Additional options can be set here if needed
                };

                // Save the filtered image back to the templates folder
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}