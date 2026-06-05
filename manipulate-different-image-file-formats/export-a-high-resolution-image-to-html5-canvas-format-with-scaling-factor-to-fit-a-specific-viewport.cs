using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\high_res_image.svg";
        string outputPath = @"C:\Images\canvas_output.html";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the source image (SVG or any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Desired viewport size (in pixels)
                const int viewportWidth = 800;
                const int viewportHeight = 600;

                // Calculate scaling factor to fit the viewport while preserving aspect ratio
                float scaleX = (float)viewportWidth / image.Width;
                float scaleY = (float)viewportHeight / image.Height;
                float scale = Math.Min(scaleX, scaleY);

                // Configure rasterization options with the calculated scale
                var rasterOptions = new SvgRasterizationOptions
                {
                    ScaleX = scale,
                    ScaleY = scale,
                    // Optional: preserve original size as page size before scaling
                    PageSize = image.Size
                };

                // Set up HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    FullHtmlPage = true   // generate a complete HTML page
                };

                // Save the image as an HTML5 Canvas file
                image.Save(outputPath, canvasOptions);
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
 * 1. When a web developer needs to embed a high‑resolution SVG diagram into a responsive HTML5 page and wants it to automatically scale to fit an 800 × 600 pixel viewport.
 * 2. When an e‑learning platform must convert vector illustrations into canvas‑based HTML so that they render consistently across browsers without requiring external SVG support.
 * 3. When a digital signage system generates HTML5 Canvas files from large vector assets to ensure the graphics are rasterized at the correct size for a fixed‑dimension display panel.
 * 4. When a SaaS reporting tool exports charts as scalable canvas elements to embed them in client‑side dashboards while preserving aspect ratio and image quality.
 * 5. When a mobile‑first web app needs to preload high‑resolution artwork as a single HTML file that scales to the device’s viewport using C# and Aspose.Imaging.
 */