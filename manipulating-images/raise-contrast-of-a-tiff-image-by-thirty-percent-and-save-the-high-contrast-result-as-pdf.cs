using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\sample.tif";
            string outputPath = @"C:\temp\sample_contrast.pdf";

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
                // Cast to TiffImage to access AdjustContrast
                TiffImage tiffImage = (TiffImage)image;

                // Increase contrast by 30%
                tiffImage.AdjustContrast(30f);

                // Save the result as PDF
                tiffImage.Save(outputPath, new PdfOptions());
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
 * 1. When a developer needs to improve the readability of scanned documents by increasing the contrast of a TIFF file before converting it to a searchable PDF.
 * 2. When an application must automatically enhance medical imaging scans stored as TIFFs by raising contrast 30% and deliver the results as PDF reports.
 * 3. When a batch processing tool for archival records requires adjusting the contrast of legacy TIFF images and saving them as PDF for easier distribution.
 * 4. When a web service generates high‑contrast PDF previews of uploaded TIFF photographs for e‑commerce product listings.
 * 5. When a document management system needs to normalize the visual quality of incoming TIFF invoices by applying a 30% contrast boost and storing them as PDFs.
 */