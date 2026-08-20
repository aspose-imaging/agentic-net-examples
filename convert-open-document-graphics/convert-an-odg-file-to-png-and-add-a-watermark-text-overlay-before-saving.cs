// HOW-TO: Convert ODG to PNG with Watermark Text Overlay in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.odg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image odgImage = Image.Load(inputPath))
            {
                // Prepare PNG rasterization options for the ODG vector image
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        PageSize = odgImage.Size,
                        BackgroundColor = Color.White
                    }
                };

                // Rasterize ODG to a memory stream as PNG
                using (var ms = new MemoryStream())
                {
                    odgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG for drawing
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Draw watermark text
                        Graphics graphics = new Graphics(raster);
                        Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 48);
                        using (SolidBrush brush = new SolidBrush(Color.Yellow))
                        {
                            graphics.DrawString("Watermark", font, brush, new PointF(10, 10));
                        }

                        // Save final PNG with watermark
                        raster.Save(outputPath, new PngOptions());
                    }
                }
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
 * 1. When you need to publish an OpenDocument graphic as a PNG for a web page while branding it with a company logo or text.
 * 2. When an automated report generator must convert ODG diagrams to PNG thumbnails and add a confidential watermark before distribution.
 * 3. When a document management system stores drawings in ODG format and requires watermarked PNG previews for user download.
 * 4. When a batch‑processing tool has to rasterize multiple ODG files to PNG and embed copyright text to protect intellectual property.
 * 5. When a C# application integrates Aspose.Imaging to create watermarked PNG assets from ODG source files for marketing materials.
 */
