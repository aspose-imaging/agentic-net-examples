// HOW-TO: Convert ODG to JPEG with Custom Quality and Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.odg";
            string outputPath = "Output\\sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 90,
                    VectorRasterizationOptions = new OdgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    }
                };

                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to generate a high‑quality JPEG preview of an OpenDocument graphic for web display.
 * 2. When you must batch‑convert ODG diagrams to JPEG images while preserving background color and page dimensions.
 * 3. When a reporting tool requires rasterizing vector ODG files into JPEGs with a specific compression level.
 * 4. When integrating Aspose.Imaging into a C# application to create thumbnails of ODG files for a document management system.
 * 5. When automating image processing pipelines that need to load ODG files, set JPEG quality, and save them as JPEGs for downstream consumption.
 */
