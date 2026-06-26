using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (size = 5, sigma = 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the filtered image as PDF
                PdfOptions pdfOptions = new PdfOptions();
                rasterImage.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to soften the details of a PNG screenshot before embedding it in a PDF report for a client presentation.
 * 2. When an application must automatically apply a Gaussian blur to scanned photos to protect privacy and then export the blurred images as searchable PDF files.
 * 3. When a web service generates product catalogs by blurring background textures of PNG assets and converting them into PDF pages for printing.
 * 4. When a medical imaging tool requires de‑identifying patient images with a Gaussian blur filter before saving them as PDF documents for compliance.
 * 5. When a batch‑processing script has to prepare marketing visuals by applying a Gaussian blur to PNG logos and then bundle them into PDF flyers using C# and Aspose.Imaging.
 */