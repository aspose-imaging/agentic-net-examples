using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\corrupted.tif";
            string outputPath = "output\\recovered.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the corrupted TIFF with recovery mode
            using (TiffImage image = (TiffImage)Image.Load(
                inputPath,
                new LoadOptions
                {
                    DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                    DataBackgroundColor = Color.White
                }))
            {
                // Example further processing: output image dimensions
                Console.WriteLine($"Recovered image size: {image.Width}x{image.Height}");

                // Save the recovered image
                image.Save(outputPath);
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
 * 1. When a medical imaging system receives a corrupted DICOM‑derived TIFF scan, a developer can use this code to recover the image with Aspose.Imaging’s ConsistentRecover mode and then extract its dimensions for further analysis.
 * 2. When an archival workflow encounters damaged high‑resolution TIFF photographs, the snippet enables automatic recovery and saving of a clean TIFF so the files can be indexed by a digital asset management system.
 * 3. When a document management application needs to open user‑uploaded TIFF attachments that may be partially corrupted, the code restores the image and provides its width and height for layout calculations.
 * 4. When a batch‑processing service must sanitize scanned TIFF invoices with missing data, the recovery mode fills background gaps with white and saves a repaired file for OCR processing.
 * 5. When a GIS platform imports satellite imagery stored as TIFF and some files are corrupted during transfer, this example recovers the raster, confirms its size, and writes a repaired file for subsequent geospatial analysis.
 */