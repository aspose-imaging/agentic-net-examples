// HOW-TO: Convert OTG to PNG with Text Watermark Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.otg";
        string outputPath = "output\\converted.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };
                pngOptions.VectorRasterizationOptions = rasterOptions;

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                    {
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(raster);
                        var font = new Aspose.Imaging.Font("Arial", 48);
                        var brush = new SolidBrush(Aspose.Imaging.Color.Yellow);
                        graphics.DrawString("Watermark", font, brush, new Aspose.Imaging.PointF(10, 10));

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
 * 1. When you need to convert proprietary OTG vector drawings to PNG thumbnails and embed a branding watermark for online galleries.
 * 2. When generating preview images of engineering schematics stored as OTG files and you want to overlay copyright text before saving.
 * 3. When preparing OTG artwork for a web portal and must add a semi‑transparent watermark to deter unauthorized reuse.
 * 4. When automating a batch job that converts OTG files to PNG format while stamping each image with a project identifier.
 * 5. When integrating Aspose.Imaging in a C# application to display OTG diagrams as PNGs with a custom watermark in a document management system.
 */
