using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\result.png";

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
            // Load SVG with load options
            using (Image image = Image.Load(inputPath, new Aspose.Imaging.ImageLoadOptions.SvgLoadOptions()))
            {
                // Save as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Aspose.Imaging.CoreExceptions.ImageFormats.SvgImageException ex)
        {
            // Log SVG-specific loading errors
            Console.Error.WriteLine($"SVG loading error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Log any other errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}