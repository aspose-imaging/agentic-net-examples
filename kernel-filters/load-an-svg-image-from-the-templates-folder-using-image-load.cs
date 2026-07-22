using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "templates/example.svg";
            string outputPath = "output/example.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG conversion
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image as PNG
                image.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to convert an SVG template stored in the project’s “templates” folder into a PNG file for web display or email attachments.
 * 2. When an application must verify the existence of an SVG asset before rasterizing it to a bitmap format to avoid runtime errors.
 * 3. When a C# service generates dynamic graphics by loading vector SVG logos and saving them as PNGs with the same dimensions for consistent branding.
 * 4. When a batch processing tool has to ensure the output directory exists and then rasterize multiple SVG files to PNG using Aspose.Imaging’s SvgRasterizationOptions.
 * 5. When troubleshooting image conversion, a developer uses a try‑catch block around Image.Load and image.Save to capture and log any exceptions during SVG to PNG transformation.
 */