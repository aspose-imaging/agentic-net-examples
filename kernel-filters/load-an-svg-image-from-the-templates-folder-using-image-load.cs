using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("templates", "sample.svg");
            string outputPath = Path.Combine("output", "sample.png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image using Image.Load
            using (Image image = Image.Load(inputPath))
            {
                // Prepare rasterization options for PNG output
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the rasterized image to PNG
                image.Save(outputPath, pngOptions);
            }

            Console.WriteLine($"SVG image loaded from '{inputPath}' and saved as PNG to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos stored in a “templates” folder, it can load the SVG with Image.Load and rasterize it to PNG for fast display.
 * 2. When an e‑commerce platform wants to convert product vector illustrations (SVG files) into high‑resolution PNG images for email newsletters, this code loads the SVG and saves it as PNG with the correct page size.
 * 3. When a reporting tool must embed company‑branded SVG icons into PDF reports that only support raster images, developers can use Image.Load to read the SVG from the templates directory and export it as PNG.
 * 4. When a desktop publishing software automates batch processing of SVG assets into PNG assets for print‑ready PDFs, the code loads each SVG from the templates folder and saves a rasterized PNG version.
 * 5. When a CI/CD pipeline validates that SVG design assets in the “templates” repository are renderable by converting them to PNG and checking the output, Image.Load is used to read the SVG before saving it as PNG.
 */