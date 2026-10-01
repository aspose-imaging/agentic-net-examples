// HOW-TO: Invert Image Colors and Save as PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                Color[] colors = raster.LoadPixels(raster.Bounds);
                int[] argb = new int[colors.Length];

                for (int i = 0; i < colors.Length; i++)
                {
                    int a = colors[i].A;
                    int r = colors[i].R;
                    int g = colors[i].G;
                    int b = colors[i].B;

                    int rgb = (r << 16) | (g << 8) | b;
                    int invertedRgb = (~rgb) & 0x00FFFFFF;

                    argb[i] = (a << 24) | invertedRgb;
                }

                raster.SaveArgb32Pixels(raster.Bounds, argb);

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    raster.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a PDF report that shows a negative‑film version of a product photo stored as PNG.
 * 2. When an e‑learning platform requires inverted screenshots to improve readability on dark‑mode slides and wants them packaged as PDF.
 * 3. When a document‑automation system must embed a color‑inverted raster image into a PDF for watermark or security purposes.
 * 4. When a batch‑processing tool has to convert a folder of PNG images to PDFs with their colors reversed for artistic effects.
 * 5. When a web service creates printable PDFs from user‑uploaded images and applies a color inversion filter to meet branding guidelines.
 */
