using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = "Sample.eps";
            string outputPath = "Sample.pdf";

            // Verify that the input EPS file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Configure PDF options with balanced compression settings
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        // Use Flate compression (good compression without quality loss)
                        Compression = PdfImageCompressionOptions.Flate,
                        // JPEG quality for rasterized images (85 gives a good trade‑off)
                        JpegQuality = 85
                    }
                };

                // Save the EPS as a PDF using the configured options
                image.Save(outputPath, pdfOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a print shop needs to convert customer‑submitted EPS artwork to PDF for online proofing while keeping the file small enough for quick email delivery, they can use this code to set Flate compression and an 85 % JPEG quality.
 * 2. When a web application generates downloadable product catalogs from EPS designs and must limit the PDF size to stay under bandwidth caps, the developer can apply the balanced compression settings shown.
 * 3. When an automated document workflow converts EPS logos to PDF for inclusion in reports and wants to preserve visual fidelity without inflating the report size, this code provides the needed quality‑size trade‑off.
 * 4. When a mobile app syncs EPS‑based graphics to a cloud service and needs PDFs that load fast on low‑speed connections, the developer can use the Flate compression and JPEG quality parameters to achieve that.
 * 5. When a corporate branding system archives EPS assets as PDFs and must store thousands of files efficiently while retaining acceptable image quality, this snippet demonstrates how to configure Aspose.Imaging compression options in C#.
 */