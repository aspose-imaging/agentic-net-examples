// HOW-TO: How To Deskew A TIFF And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
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
            using (Image image = Image.Load(inputPath))
            {
                // Deskew the image (applicable to raster images)
                if (image is RasterImage raster)
                {
                    // Do not resize, use LightGray as background
                    raster.NormalizeAngle(false, Color.LightGray);
                }

                // Save the corrected image as PDF
                var pdfOptions = new PdfOptions();
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
 * 1. When scanning legal documents that are slightly tilted, a developer can deskew the TIFF and output a clean PDF for archiving.
 * 2. When converting batches of scanned invoices from TIFF to searchable PDF, the code ensures each page is straightened before saving.
 * 3. When preparing medical records scanned as TIFF files, deskewing improves readability before generating PDF reports.
 * 4. When building a document management system that receives uploaded TIFF images, the routine automatically corrects orientation and stores them as PDFs.
 * 5. When automating the digitization workflow for historical archives, the code removes skew from TIFF scans and creates PDF files for distribution.
 */
