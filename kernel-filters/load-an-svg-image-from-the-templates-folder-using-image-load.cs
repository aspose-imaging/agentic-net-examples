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
            string inputPath = "templates/sample.svg";
            string outputPath = "output/sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image using Aspose.Imaging.Image.Load
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
 * 1. When a web application needs to generate thumbnail previews of user‑uploaded SVG logos for display on a dashboard, a developer can load the SVG from the templates folder and rasterize it to PNG with Aspose.Imaging.
 * 2. When an e‑commerce platform wants to create printable product labels from vector SVG templates and store them as high‑resolution PNG files for downstream printing workflows, this code can be used.
 * 3. When a reporting service must embed scalable vector graphics into PDF reports but the PDF engine only accepts raster images, a developer can load the SVG and convert it to PNG on the fly.
 * 4. When a mobile app requires pre‑rendered PNG assets derived from SVG icons to reduce runtime processing on devices, the code can batch‑process the template SVGs into PNGs.
 * 5. When an automated CI/CD pipeline needs to verify that SVG design assets render correctly by converting them to PNG and comparing pixel outputs, the developer can employ this Image.Load and save routine.
 */