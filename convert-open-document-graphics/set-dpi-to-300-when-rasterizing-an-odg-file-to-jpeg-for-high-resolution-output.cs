// HOW-TO: Rasterize ODG to High Resolution JPEG at 300 DPI in C# (Aspose.Imaging for .NET)
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
                JpegOptions jpegOptions = new JpegOptions();
                jpegOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                jpegOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = image.Width,
                    PageHeight = image.Height
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
 * 1. When converting LibreOffice Draw (ODG) diagrams to JPEG for print‑ready brochures, you need 300 DPI high‑resolution images.
 * 2. When generating thumbnails for a document management system that requires consistent DPI settings, you can rasterize ODG files to JPEG at 300 DPI.
 * 3. When preparing engineering schematics stored as ODG for inclusion in PDF reports, setting the DPI ensures the JPEG retains detail.
 * 4. When automating batch conversion of ODG assets for a web‑based catalog that demands high‑quality product images, you use this code to enforce 300 DPI.
 * 5. When integrating Aspose.Imaging into a C# application that must export vector drawings as JPEGs for archival purposes, setting the resolution guarantees lossless‑looking output.
 */
