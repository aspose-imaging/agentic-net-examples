using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths (preserve original filename)
        string inputPath = "templates/example.svg";
        string outputPath = inputPath;

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
            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Save the SVG image back to the same location
                var options = new SvgOptions();
                image.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application uses Aspose.Imaging for .NET to apply an SVG filter and needs to overwrite the original template file in the templates folder while preserving its filename.
 * 2. When an automated build script loads SVG assets with Image.Load, processes them, and saves the modified SVG back to the same location using SvgOptions to keep the project’s folder structure unchanged.
 * 3. When a desktop utility updates branding colors in SVG logos stored in a templates directory and must write the filtered image back with the original example.svg name for downstream design tools.
 * 4. When a CI/CD pipeline validates and normalizes SVG files, then uses image.Save to replace each file in the source folder, ensuring version‑control consistency without renaming files.
 * 5. When a batch job iterates over SVG templates, applies a watermark or other image processing operation, and overwrites each file while maintaining the existing file path and name.
 */