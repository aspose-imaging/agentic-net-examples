// HOW-TO: Add Text Watermark to BMP After SVG Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input SVG and output BMP paths
            string inputPath = "input.svg";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null‑safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Rasterize SVG to BMP
            using (Image svgImage = Image.Load(inputPath))
            {
                var bmpOptions = new BmpOptions();
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                bmpOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(outputPath, bmpOptions);
            }

            // Load the rasterized BMP and add watermark text
            using (Image bmpImage = Image.Load(outputPath))
            {
                RasterImage raster = (RasterImage)bmpImage;
                Graphics graphics = new Graphics(raster);

                // Prepare brush for text drawing
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Red;
                    brush.Opacity = 100;

                    // Draw watermark text
                    graphics.DrawString(
                        "Watermark",
                        new Font("Arial", 48, FontStyle.Regular),
                        brush,
                        new PointF(10, 10));
                }

                // Save changes to the same BMP file
                raster.Save();
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
 * 1. When you need to convert an SVG logo to a BMP file and embed a visible copyright notice directly onto the image in a C# application.
 * 2. When generating printable assets where the source vector must be rasterized to BMP and a branding text must be overlaid before saving.
 * 3. When automating batch processing of SVG diagrams to BMP thumbnails and require each thumbnail to carry a watermark for security or tracking.
 * 4. When creating a server‑side service that receives SVG uploads, rasterizes them to BMP, and adds a custom watermark for client‑specific identification.
 * 5. When developing a desktop tool that lets users preview SVG artwork as BMP and apply editable text watermarks using Aspose.Imaging’s drawing API.
 */
