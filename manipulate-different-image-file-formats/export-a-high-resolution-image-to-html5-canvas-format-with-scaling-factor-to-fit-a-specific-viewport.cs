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
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.html";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Desired viewport size (example: 800x600)
                const int viewportWidth = 800;
                const int viewportHeight = 600;

                // Calculate scaling factors to fit the viewport while preserving aspect ratio
                float scaleX = (float)viewportWidth / svgImage.Width;
                float scaleY = (float)viewportHeight / svgImage.Height;
                float scale = Math.Min(scaleX, scaleY); // uniform scaling

                // Configure rasterization options with the calculated scale
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    ScaleX = scale,
                    ScaleY = scale,
                    // Preserve original size as the base for scaling
                    PageSize = svgImage.Size
                };

                // Configure HTML5 Canvas export options
                var canvasOptions = new Html5CanvasOptions
                {
                    VectorRasterizationOptions = rasterizationOptions,
                    FullHtmlPage = true // generate a full HTML page
                };

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as an HTML5 Canvas file
                svgImage.Save(outputPath, canvasOptions);
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
 * 1. When a web developer needs to embed a high‑resolution SVG diagram into an HTML5 Canvas element that automatically scales to fit a fixed 800×600 viewport, they can use this C# Aspose.Imaging code to rasterize and export the image with uniform scaling.
 * 2. When an e‑learning platform must convert vector illustrations stored as SVG files into responsive HTML5 Canvas pages for offline viewing on tablets, the code provides the necessary rasterization options and viewport‑aware scaling.
 * 3. When a digital signage system requires pre‑rendered HTML5 Canvas assets from SVG logos that adapt to different screen sizes while preserving aspect ratio, this Aspose.Imaging snippet generates the scaled HTML output programmatically.
 * 4. When a reporting tool generates PDF‑like reports that include SVG charts and needs to embed them as HTML5 Canvas elements sized to a specific page layout, the code ensures the SVG is rasterized with the correct scale and saved as a full HTML page.
 * 5. When a mobile app backend processes user‑uploaded SVG icons and must deliver them as HTML5 Canvas snippets that fit within a predefined UI component, the C# example shows how to calculate the scaling factor and export the image accordingly.
 */