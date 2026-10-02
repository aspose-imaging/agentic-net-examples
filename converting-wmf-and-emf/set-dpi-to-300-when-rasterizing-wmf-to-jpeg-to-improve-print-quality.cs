// HOW-TO: Rasterize WMF to JPEG with 300 DPI for Print Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.wmf";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image wmfImage = Image.Load(inputPath))
            {
                WmfRasterizationOptions rasterOptions = new WmfRasterizationOptions
                {
                    PageWidth = wmfImage.Width,
                    PageHeight = wmfImage.Height,
                    BackgroundColor = Color.White
                };

                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.VectorRasterizationOptions = rasterOptions;
                    wmfImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert vector WMF diagrams into high‑resolution JPEGs for printing brochures.
 * 2. When generating thumbnails of WMF icons for web pages but require 300 dpi to maintain detail.
 * 3. When automating a batch process that prepares legacy WMF artwork for inclusion in PDF reports.
 * 4. When integrating Aspose.Imaging into a C# application that must export WMF charts as printable JPEG images.
 * 5. When a printing service expects JPEG files at 300 dpi to meet industry quality standards.
 */
