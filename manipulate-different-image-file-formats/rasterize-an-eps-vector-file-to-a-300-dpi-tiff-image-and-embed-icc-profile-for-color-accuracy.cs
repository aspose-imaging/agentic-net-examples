// HOW-TO: Convert EPS to 300 DPI TIFF with Rasterization in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (EpsImage)Image.Load(inputPath))
            {
                double widthInches = image.SizeF.Width;
                double heightInches = image.SizeF.Height;
                const int dpi = 300;
                int pixelWidth = (int)(widthInches * dpi);
                int pixelHeight = (int)(heightInches * dpi);

                var rasterOptions = new EpsRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = pixelWidth,
                    PageHeight = pixelHeight
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
                };

                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to generate high‑resolution printable TIFFs from EPS artwork for a publishing workflow using C#.
 * 2. When a desktop application must convert vector logos stored as EPS into 300 DPI raster images for inclusion in PDFs.
 * 3. When an automated build process has to batch‑process EPS files into TIFFs with exact pixel dimensions for a digital asset management system.
 * 4. When a web service receives EPS files and must return TIFF thumbnails at print quality for preview in a .NET backend.
 * 5. When you need to preserve color consistency by rasterizing EPS to TIFF at 300 DPI before applying an ICC profile in a later step.
 */
