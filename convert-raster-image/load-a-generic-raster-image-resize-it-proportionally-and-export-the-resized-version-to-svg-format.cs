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
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.svg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Define a scaling factor (e.g., 50% of original size)
                const double scaleFactor = 0.5;
                int newWidth = (int)(image.Width * scaleFactor);
                int newHeight = (int)(image.Height * scaleFactor);

                // Resize proportionally
                image.Resize(newWidth, newHeight);

                // Prepare SVG save options with rasterization settings
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = new Size(newWidth, newHeight)
                };

                var svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Save the resized image as SVG
                image.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to generate lightweight, scalable web graphics from user‑uploaded JPEG photos by shrinking them to half size and converting them to SVG for responsive design.
 * 2. When an e‑commerce platform wants to create thumbnail previews of product images that can be zoomed without loss of quality, using C# to resize the raster image and save it as an SVG vector.
 * 3. When a content management system must batch‑process legacy bitmap assets, reducing their dimensions and converting them to SVG to improve page load speed and SEO.
 * 4. When a mobile app backend requires on‑the‑fly image optimization, taking a high‑resolution PNG, scaling it down proportionally, and delivering it as an SVG to support different screen densities.
 * 5. When a reporting tool needs to embed resized charts originally rendered as raster bitmaps into PDF or HTML reports as scalable SVG graphics using Aspose.Imaging for .NET.
 */