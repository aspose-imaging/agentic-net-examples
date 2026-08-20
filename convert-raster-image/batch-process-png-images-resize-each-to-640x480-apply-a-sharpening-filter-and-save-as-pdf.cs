// HOW-TO: Batch Resize PNG to 640x480, Sharpen, and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (var inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".pdf");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    image.Resize(640, 480, ResizeType.NearestNeighbourResample);
                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());
                    var pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate printable PDFs from a folder of product photos, resizing each PNG to a standard 640x480 size and sharpening them for clearer details.
 * 2. When preparing a batch of scanned documents saved as PNG for archival, you can automatically resize, enhance, and convert them to PDF to reduce storage space and improve readability.
 * 3. When creating thumbnails for a web gallery and want the final output as PDF reports, the code resizes each image, applies a sharpening filter, and saves them as PDFs in one step.
 * 4. When automating the conversion of PNG screenshots from automated tests into PDF files with consistent dimensions and enhanced sharpness for documentation purposes.
 * 5. When building a desktop utility that processes user‑uploaded PNG images, standardizes their size, improves visual quality, and outputs them as PDFs for easy sharing or printing.
 */
