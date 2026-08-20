// HOW-TO: Resize BMP, Apply Median Filter, and Convert to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.bmp";
            string outputPath = "Output/result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Resize(300, 300);
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));
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
 * 1. When you need to generate a smaller, noise‑reduced PDF preview from a high‑resolution BMP for web display.
 * 2. When converting scanned BMP documents into PDF files while smoothing speckles using a median filter.
 * 3. When preparing thumbnail PDFs of BMP graphics for inclusion in reports or email attachments.
 * 4. When automating batch processing to downsize BMP images, remove salt‑and‑pepper noise, and archive them as PDFs.
 * 5. When integrating Aspose.Imaging in a C# application to transform BMP assets into compact PDF files with consistent dimensions.
 */
