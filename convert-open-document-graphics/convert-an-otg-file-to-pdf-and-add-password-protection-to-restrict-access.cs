using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\input\sample.otg";
            string outputPath = @"C:\output\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image image = Image.Load(inputPath))
            {
                // Set up OTG rasterization options
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF save options
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Embed a digital signature using a password to restrict access
                if (image is RasterCachedMultipageImage multiPageImage)
                {
                    multiPageImage.EmbedDigitalSignature("SecretPassword123");
                }

                // Save the image as PDF
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
 * 1. When a healthcare application needs to securely share patient diagrams stored as OTG files by converting them to password‑protected PDF reports using Aspose.Imaging for .NET.
 * 2. When an engineering firm wants to archive multi‑page OTG schematics as encrypted PDFs to comply with data‑privacy regulations.
 * 3. When a legal document management system must transform OTG evidence images into PDF files with access restrictions before uploading them to a case‑file repository.
 * 4. When a construction project portal automatically converts OTG site‑plan images to PDF and applies a password to prevent unauthorized viewing by subcontractors.
 * 5. When a desktop utility processes batches of OTG drawings, rasterizes them with Aspose.Imaging, and saves them as PDF files that require a password to open, ensuring confidential design data stays protected.
 */