using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

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
                // Set SVG save options
                var svgOptions = new SvgOptions
                {
                    // Optional: customize options here if needed
                };

                // Save as SVG
                image.Save(outputPath, svgOptions);
            }
        }
        catch (SvgImageException ex)
        {
            // Record SVG-specific errors
            Console.Error.WriteLine($"SVG save error for '{outputPath}': {ex.Message}");
        }
        catch (ImageSaveException ex)
        {
            // Record generic image save errors
            Console.Error.WriteLine($"Image save error for '{outputPath}': {ex.Message}");
        }
        catch (Exception ex)
        {
            // Record any other unexpected errors
            Console.Error.WriteLine($"Unexpected error for '{outputPath}': {ex.Message}");
        }
    }
}