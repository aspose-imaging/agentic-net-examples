using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;
using Aspose.Imaging.CoreExceptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load SVG image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (SvgImage svgImage = new SvgImage(stream))
            {
                // Set up rasterization options for SVG
                var rasterizationOptions = new SvgRasterizationOptions();

                // Configure PNG save options with rasterization
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save rasterized image to PNG
                svgImage.Save(outputPath, pngOptions);
            }
        }
        catch (SvgImageException ex)
        {
            // Log SVG-specific loading errors
            Console.Error.WriteLine($"SVG load error: {ex.Message}");
        }
        catch (ImageLoadException ex)
        {
            // Log generic image loading errors
            Console.Error.WriteLine($"Image load error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Log any other unexpected errors
            Console.Error.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}