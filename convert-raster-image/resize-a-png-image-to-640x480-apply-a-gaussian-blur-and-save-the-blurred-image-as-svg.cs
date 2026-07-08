using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Resize to 640x480
                image.Resize(640, 480);

                // Apply Gaussian blur
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5));

                // Save as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When a web developer needs to generate a lightweight SVG thumbnail from a high‑resolution PNG for responsive design, they can resize the PNG to 640×480, apply a Gaussian blur for a soft‑focus effect, and save it as SVG using Aspose.Imaging for .NET.
 * 2. When an e‑learning platform wants to create blurred background images for slide overlays, the code can take the original PNG assets, downscale them to 640×480, apply a Gaussian blur, and export them as SVG vectors that scale without loss.
 * 3. When a marketing automation tool must produce stylized SVG icons from product photos, developers can use this snippet to resize the PNGs, add a subtle blur, and output SVG files that are easy to embed in email templates.
 * 4. When a desktop application needs to preprocess user‑uploaded PNG screenshots for a preview pane, the code resizes the images to a standard 640×480 size, softens them with a Gaussian blur, and saves them as SVG for fast rendering.
 * 5. When a data‑visualization service wants to convert PNG charts into scalable SVG graphics with a blurred background for visual emphasis, the snippet performs the resize, blur, and format conversion in a single C# workflow.
 */