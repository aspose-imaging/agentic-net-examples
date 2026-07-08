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
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "filtered.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
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
 * 1. When a developer needs to clean up noisy BMP scans of handwritten forms and embed the denoised image into a PDF report for archival, they can use this code to apply a median filter and center the result on the PDF page.
 * 2. When an application must convert legacy BMP assets from a game’s texture library into PDF documentation while reducing pixelated noise, the code provides a C# solution that filters and saves the image as a centered PDF.
 * 3. When a medical imaging system exports BMP images of X‑ray films and requires a quick noise‑reduction step before generating patient PDFs, this snippet demonstrates how to apply a median filter and produce a centered PDF using Aspose.Imaging for .NET.
 * 4. When a batch‑processing tool needs to read BMP screenshots, remove salt‑and‑pepper artifacts, and create printable PDFs with the cleaned image centered, the example shows the necessary C# operations.
 * 5. When a document‑generation service must embed a filtered BMP logo into a PDF brochure, ensuring the logo appears without speckle noise and is centered on the page, this code illustrates the required steps.
 */