using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.pdf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Configure PDF export options with anti‑aliasing
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        // Enable smoother edges
                        SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias,
                        // Match the PDF page size to the source image dimensions
                        PageSize = new SizeF(tiffImage.Width, tiffImage.Height)
                    }
                };

                // Save the image as PDF using the configured options
                tiffImage.Save(outputPath, pdfOptions);
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
 * 1. When converting scanned engineering drawings stored as TIFF files to PDF for client review, a developer uses this code to apply AntiAlias smoothing so that fine lines and curves appear crisp and free of jagged edges.
 * 2. When generating printable PDF catalogs from high‑resolution product photos saved as TIFF, the AntiAlias smoothing mode ensures the images retain smooth borders and professional visual quality.
 * 3. When automating the archival of medical imaging reports that include TIFF‑based diagrams, the code renders them to PDF with anti‑aliasing to preserve diagnostic detail without pixelation.
 * 4. When creating PDF invoices that embed TIFF‑formatted company logos, developers enable SmoothingMode.AntiAlias to keep the logo’s edges smooth and visually appealing on any device.
 * 5. When building a batch conversion tool that transforms large batches of TIFF maps into PDF for GIS analysts, the anti‑alias setting guarantees that map lines and symbols render with clean, smooth edges.
 */