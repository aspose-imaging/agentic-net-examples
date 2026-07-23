using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Deskew the image (do not resize, use white background)
                image.NormalizeAngle(false, Color.White);

                // Save the corrected image as PDF
                image.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to automatically correct the skew of scanned TIFF documents (such as invoices or contracts) and archive them as searchable PDF files using C# and Aspose.Imaging.
 * 2. When a batch‑processing service must validate that incoming multi‑page TIFF files are properly aligned before converting them to PDF for downstream OCR pipelines.
 * 3. When an enterprise application integrates a document‑upload feature that receives rotated TIFF images from mobile scanners and must deskew them on the server before saving as PDF for compliance records.
 * 4. When a digital‑archiving tool requires straightening legacy TIFF scans and storing the results in PDF format to reduce storage size and improve viewing consistency across platforms.
 * 5. When a C# console utility is needed to verify the existence of a TIFF file, correct its orientation using NormalizeAngle with a white background, and output a PDF for easy distribution to clients.
 */