// HOW-TO: Batch Increase Brightness of TIFF Images and Save as PDF in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all TIFF files in the input folder
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in tiffFiles)
            {
                // Process only .tif and .tiff extensions
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".tif" && extension != ".tiff")
                    continue;

                // Verify the input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Prepare output PDF path
                string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists (unconditional as required)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(filePath))
                {
                    // Cast to TiffImage to access AdjustBrightness
                    TiffImage tiffImage = (TiffImage)image;

                    // Adjust brightness (example value: 50)
                    tiffImage.AdjustBrightness(50);

                    // Save as PDF
                    tiffImage.Save(outputPath, new PdfOptions());
                }
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
 * 1. When you need to improve the visibility of scanned TIFF documents before archiving them as searchable PDFs.
 * 2. When a medical imaging workflow requires brightening multiple TIFF X‑ray files and converting them to PDF for patient records.
 * 3. When a publishing system must automatically enhance the brightness of a batch of TIFF artwork files and output them as PDF proofs.
 * 4. When a legal firm wants to batch‑process TIFF evidence photos, increase their brightness, and store them in PDF format for case files.
 * 5. When an automated script must convert a folder of low‑contrast TIFF scans into brighter PDFs for easier viewing on mobile devices.
 */
