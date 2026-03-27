using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output\\result.psd";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure PSD saving options
                PsdOptions options = new PsdOptions
                {
                    CompressionMethod = CompressionMethod.RLE,
                    ColorMode = ColorModes.Rgb
                };

                // Save the image as PSD
                image.Save(outputPath, options);
            }
        }
        catch (Aspose.Imaging.CoreExceptions.ImageFormats.PsdImageException ex)
        {
            // Handle PSD-specific saving errors
            Console.Error.WriteLine($"PSD saving error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle any other unexpected errors
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}