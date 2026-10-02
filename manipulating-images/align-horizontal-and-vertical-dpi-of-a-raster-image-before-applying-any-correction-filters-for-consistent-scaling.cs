// HOW-TO: Align Horizontal and Vertical DPI of JPEG with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double targetDpi = Math.Max(image.HorizontalResolution, image.VerticalResolution);
                image.HorizontalResolution = targetDpi;
                image.VerticalResolution = targetDpi;

                JpegOptions options = new JpegOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to ensure a JPEG photo prints at the correct size by making its horizontal and vertical DPI identical.
 * 2. When preparing images for a web gallery that requires consistent scaling across devices, you must normalize the DPI before applying any correction filters.
 * 3. When a batch processing pipeline must standardize image resolution to avoid distortion after resizing or rotating operations.
 * 4. When integrating Aspose.Imaging into a C# application that imports scanned documents with mismatched DPI values and needs uniform resolution for OCR.
 * 5. When converting images from various sources to a single DPI setting to maintain aspect‑ratio consistency in a PDF generation workflow.
 */
