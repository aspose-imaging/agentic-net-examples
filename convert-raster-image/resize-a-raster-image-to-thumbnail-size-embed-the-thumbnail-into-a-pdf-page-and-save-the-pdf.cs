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
            // Define input and output paths
            string inputPath = "Input\\sample.jpg";
            string outputPath = "Output\\thumbnail.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image, resize to thumbnail, and save as PDF
            using (Image image = Image.Load(inputPath))
            {
                // Resize to thumbnail size (e.g., 150x150)
                image.Resize(150, 150);

                // Create PDF options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the resized image as a PDF page
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
 * 1. When a web application needs to generate a quick preview of user‑uploaded JPEG photos as a 150 × 150 thumbnail embedded in a PDF report for download.
 * 2. When an e‑commerce platform wants to create printable product catalogs by converting resized product images into single‑page PDF files.
 * 3. When a document management system must archive scanned documents as PDFs while storing a small thumbnail for faster visual indexing.
 * 4. When a mobile app backend processes camera images, creates a thumbnail, and bundles it into a PDF to send to email or messaging services.
 * 5. When a corporate intranet tool automatically converts employee ID badge photos into thumbnail PDFs for inclusion in HR onboarding packets.
 */