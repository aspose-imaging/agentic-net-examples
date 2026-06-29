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
            string inputPath = @"C:\Images\highres.svg";
            string outputPath = @"C:\Images\canvas.html";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (SVG in this example)
            using (Image image = Image.Load(inputPath))
            {
                // Desired viewport size
                int targetWidth = 800;   // pixels
                int targetHeight = 600;  // pixels

                // Compute scaling factors based on original SVG size
                float scaleX = 1f;
                float scaleY = 1f;
                if (image is SvgImage svgImage && svgImage.Size.Width > 0 && svgImage.Size.Height > 0)
                {
                    scaleX = (float)targetWidth / svgImage.Size.Width;
                    scaleY = (float)targetHeight / svgImage.Size.Height;
                }

                // Configure rasterization options with scaling
                var rasterOptions = new SvgRasterizationOptions
                {
                    ScaleX = scaleX,
                    ScaleY = scaleY
                };

                // Set up HTML5 Canvas export options
                var htmlOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    FullHtmlPage = true   // generate a complete HTML page
                };

                // Save as HTML5 Canvas
                image.Save(outputPath, htmlOptions);
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
 * 1. When a developer needs to embed a high‑resolution SVG into a responsive web page, they can use this code to export the image to an HTML5 Canvas with scaling that fits a specific viewport.
 * 2. When a C# application must generate a printable preview of a vector graphic at a fixed size, this snippet rasterizes the SVG and saves it as a full HTML page sized to the target dimensions.
 * 3. When an e‑learning platform requires dynamic resizing of SVG illustrations for different screen resolutions, the code provides a way to compute ScaleX/ScaleY and output a Canvas‑based HTML file.
 * 4. When a desktop tool automates conversion of design assets into web‑ready formats, this example shows how to load an SVG, apply custom scaling, and save it as an HTML5 Canvas document.
 * 5. When a developer wants to ensure that vector images render consistently across browsers by converting them to rasterized Canvas elements sized to 800 × 600 pixels, this code performs the necessary image processing and export.
 */