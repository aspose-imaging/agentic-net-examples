using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = @"C:\Images\input.png";
        string outputPngPath = @"C:\Images\output_blurred.png";
        string outputPdfPath = @"C:\Images\output_preview.pdf";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768
                image.Resize(1024, 768);

                // Apply Gaussian blur to the entire image
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Ensure output directory exists for PNG
                Directory.CreateDirectory(Path.GetDirectoryName(outputPngPath));

                // Save the blurred image as PNG
                image.Save(outputPngPath, new PngOptions());

                // Ensure output directory exists for PDF
                Directory.CreateDirectory(Path.GetDirectoryName(outputPdfPath));

                // Save the same blurred image as PDF for preview
                var pdfOptions = new PdfOptions();
                image.Save(outputPdfPath, pdfOptions);
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
 * 1. When a web application needs to generate a 1024×768 PNG thumbnail with a Gaussian blur and also provide a PDF preview for users to view the softened image.
 * 2. When an e‑commerce platform automatically resizes product PNG images, applies a blur to de‑emphasize background details, and creates a PDF version for catalog generation.
 * 3. When a desktop presentation tool prepares a blurred background image by resizing a PNG to slide dimensions and exporting it as a PDF for quick slide preview.
 * 4. When a content management system processes uploaded PNG assets, standardizes their size, adds a Gaussian blur for visual effect, and stores both PNG and PDF files for web and offline distribution.
 * 5. When a reporting service converts high‑resolution PNG charts into a smaller, blurred PNG and a PDF preview to embed in generated PDF reports.
 */