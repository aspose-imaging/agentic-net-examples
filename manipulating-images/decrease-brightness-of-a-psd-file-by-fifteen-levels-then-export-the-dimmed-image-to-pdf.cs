// HOW-TO: How To Decrease PSD Brightness By 15 And Save As PDF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.psd";
            string outputPath = "output.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PSD image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage to perform brightness adjustment
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                // Decrease brightness by 15 levels
                raster.AdjustBrightness(-15);

                // Prepare PDF options
                PdfOptions pdfOptions = new PdfOptions();

                // Save the adjusted image as PDF
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
 * 1. When you need to dim a Photoshop PSD file before embedding it in a PDF report.
 * 2. When automating batch processing to lower the brightness of PSD images for print‑ready PDFs.
 * 3. When creating a web service that receives PSD uploads, reduces their brightness, and returns a PDF preview.
 * 4. When preparing marketing assets where a slightly darker version of the original PSD is required for background consistency in PDF brochures.
 * 5. When integrating image preprocessing into a C# application that converts edited PSD layers into PDF for archival storage.
 */
