using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Sample.eps";
        string outputPath = "Sample_Landscape.pdf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Prepare PDF conversion options
                var pdfOptions = new PdfOptions();

                // Configure rasterization options to enforce landscape orientation
                var rasterOptions = new EpsRasterizationOptions();

                // If the source EPS is portrait, swap width and height to get landscape
                if (image.Width < image.Height)
                {
                    rasterOptions.PageWidth = image.Height;
                    rasterOptions.PageHeight = image.Width;
                }
                else
                {
                    rasterOptions.PageWidth = image.Width;
                    rasterOptions.PageHeight = image.Height;
                }

                // Assign rasterization options to PDF options
                pdfOptions.VectorRasterizationOptions = rasterOptions;

                // Save as PDF with the specified options
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
 * 1. When a developer needs to embed wide EPS diagrams such as architectural floor plans into a PDF report and must force landscape orientation to preserve readability.
 * 2. When an automated document generation system converts a batch of EPS logos or banners to PDF and must ensure each output page is oriented horizontally regardless of the source dimensions.
 * 3. When a printing workflow requires EPS artwork to be rasterized into PDF with landscape layout to match printer tray settings for large‑format prints.
 * 4. When a web application allows users to upload EPS charts and needs to deliver downloadable PDFs that automatically switch to landscape for better on‑screen viewing.
 * 5. When a CI/CD pipeline validates EPS assets and generates landscape PDFs for quality‑assurance reviews, using Aspose.Imaging’s rasterization options to swap width and height when necessary.
 */