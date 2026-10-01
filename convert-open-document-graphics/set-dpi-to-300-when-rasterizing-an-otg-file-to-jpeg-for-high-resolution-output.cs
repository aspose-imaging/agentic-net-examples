// HOW-TO: Rasterize OTG to High-Resolution JPEG at 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.otg";
            string outputPath = "Output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                JpegOptions jpegOptions = new JpegOptions
                {
                    ResolutionSettings = new ResolutionSetting(300, 300),
                    VectorRasterizationOptions = new VectorRasterizationOptions
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
 * 1. When you need to convert a vector OTG design into a print‑ready JPEG with 300 DPI for high‑quality brochures.
 * 2. When generating thumbnails for an OTG catalog but require the same resolution as the original for detailed inspection.
 * 3. When preparing OTG artwork for a marketing email that must retain sharpness on high‑resolution displays.
 * 4. When archiving OTG files as JPEGs for a document management system that only supports raster images at a specific DPI.
 * 5. When integrating an automated pipeline that transforms OTG drawings into JPEGs for a GIS application that expects 300 DPI raster layers.
 */
