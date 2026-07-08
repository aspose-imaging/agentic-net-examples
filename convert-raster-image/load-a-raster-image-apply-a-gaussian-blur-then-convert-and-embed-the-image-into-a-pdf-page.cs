using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
        string outputPath = @"C:\Images\sample_blurred.pdf";

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

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Prepare PDF export options
                var pdfOptions = new PdfOptions();

                // Save the blurred image as a PDF page
                raster.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate a PDF report that includes a blurred version of a PNG logo to protect brand identity while still showing its shape.
 * 2. When an e‑commerce site wants to embed a softened product thumbnail into a PDF invoice to reduce visual distraction.
 * 3. When a medical imaging application must anonymize patient photos by applying a Gaussian blur before archiving them as PDF documents.
 * 4. When a marketing tool automatically converts user‑uploaded images into PDF flyers with a subtle blur effect for background visuals.
 * 5. When a document management system requires batch processing of raster images, applying a Gaussian blur for aesthetic purposes, and saving them directly as PDF pages using C# and Aspose.Imaging.
 */