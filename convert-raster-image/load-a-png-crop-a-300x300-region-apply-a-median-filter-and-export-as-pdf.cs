// HOW-TO: Crop PNG, Apply Median Filter, and Save as PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.png";
        string outputPath = "Output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Crop a 300x300 region from the top-left corner
                raster.Crop(new Rectangle(0, 0, 300, 300));

                // Apply a median filter with size 5 to the entire image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                // Save the processed image as PDF
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
 * 1. When you need to extract a 300 × 300 thumbnail from a PNG, reduce noise with a median filter, and deliver the result as a PDF report.
 * 2. When generating printable PDFs from scanned PNG images while removing speckles by applying a median filter to a specific region.
 * 3. When creating a PDF catalog that shows a cropped portion of product images and requires noise reduction for clearer visuals.
 * 4. When automating a workflow that converts uploaded PNG logos into PDF assets after cropping and smoothing the image.
 * 5. When preprocessing PNG screenshots for documentation by cropping a focus area, denoising it, and exporting directly to PDF.
 */
