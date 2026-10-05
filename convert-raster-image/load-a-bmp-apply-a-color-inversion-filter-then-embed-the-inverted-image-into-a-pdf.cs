// HOW-TO: Invert BMP Colors and Save as PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;
                var rect = raster.Bounds;
                int[] pixels = raster.LoadArgb32Pixels(rect);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }
                raster.SaveArgb32Pixels(rect, pixels);
                raster.Save(outputPath, new PdfOptions());
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
 * 1. When you need to generate a printable PDF that shows a negative‑film effect of an existing BMP photograph.
 * 2. When a document‑generation system must embed a color‑inverted version of a bitmap logo into a PDF report.
 * 3. When an archival workflow requires converting legacy BMP scans to PDF while applying a visual contrast enhancement.
 * 4. When a web service creates PDF previews of user‑uploaded BMP images with inverted colors for accessibility testing.
 * 5. When a batch‑processing tool automates the transformation of BMP assets into PDF files with a reversed color palette for branding guidelines.
 */
