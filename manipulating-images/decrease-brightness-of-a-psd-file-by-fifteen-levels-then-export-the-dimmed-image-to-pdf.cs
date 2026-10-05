// HOW-TO: Decrease PSD Brightness By 15 And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputPath = "input.psd";
        string outputPath = "output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    raster.AdjustBrightness(-15);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                image.Save(outputPath, new PdfOptions());
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
 * 1. When you need to dim a Photoshop document before generating a printable PDF for a marketing brochure.
 * 2. When an automated workflow must reduce the visual intensity of PSD assets to meet brand guidelines and then archive them as PDFs.
 * 3. When a server‑side service processes user‑uploaded PSD files, lowers their brightness to improve readability, and returns a PDF preview.
 * 4. When a batch script prepares design files for e‑learning modules by darkening the images and converting them to PDF for consistent viewing.
 * 5. When a desktop application offers a “quick export” feature that adjusts image brightness and saves the result as a PDF for client review.
 */
