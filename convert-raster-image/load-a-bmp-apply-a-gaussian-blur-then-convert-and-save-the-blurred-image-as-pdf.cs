using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.bmp";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image as PDF
                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When a developer needs to generate a PDF report that includes a blurred version of a scanned BMP document for privacy or visual effect.
 * 2. When an application must preprocess a BMP image by applying a Gaussian blur to reduce noise before embedding it into a PDF brochure.
 * 3. When a web service converts user‑uploaded BMP files to PDF while automatically softening the image with a Gaussian blur to meet branding guidelines.
 * 4. When a batch job processes legacy BMP assets, applies a Gaussian blur for artistic styling, and saves the results as searchable PDF files.
 * 5. When a desktop utility needs to load a BMP, apply a radius‑5 Gaussian blur, and export the result as a PDF for printing or archiving.
 */