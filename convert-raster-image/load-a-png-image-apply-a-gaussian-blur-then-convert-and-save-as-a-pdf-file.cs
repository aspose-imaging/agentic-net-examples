using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\output.pdf";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF save options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the processed image as PDF
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a PDF report from a PNG logo and wants to smooth the logo with a Gaussian blur before embedding it.
 * 2. When an e‑commerce site must convert product PNG images to PDF catalogs while applying a blur to hide sensitive details.
 * 3. When a medical imaging system requires exporting scanned PNG slides as PDF documents with a soft focus effect for presentation purposes.
 * 4. When a document automation workflow needs to take user‑uploaded PNG signatures, apply a subtle blur for privacy, and save them as PDF attachments.
 * 5. When a desktop application creates printable PDF handouts from PNG screenshots and wants to reduce pixelation by applying a Gaussian blur filter first.
 */