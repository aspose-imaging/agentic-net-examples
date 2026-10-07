// HOW-TO: Convert SVG to High Quality JPEG in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.jpg";
            string tempPath = "temp/temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                vectorImage.Save(tempPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                var jpegOptions = new JpegOptions
                {
                    Quality = 100,
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, jpegOptions);
            }

            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to generate a high‑resolution JPEG thumbnail from an SVG logo for web pages without losing vector detail.
 * 2. When a reporting system must embed vector diagrams as JPEG images in PDF reports that only accept raster formats.
 * 3. When an e‑commerce platform converts product SVG icons into JPEGs for email newsletters that require JPEG attachments.
 * 4. When a desktop application creates printable JPEG assets from user‑uploaded SVG artwork while preserving maximum quality.
 * 5. When a batch process migrates a library of SVG assets to JPEG files for legacy systems that cannot render SVG.
 */
