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
            string[] tiffFiles = Directory.GetFiles(inputFolder, "*.tif");
            string[] tiffFilesUpper = Directory.GetFiles(inputFolder, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesUpper.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesUpper.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
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
 * 1. When a medical imaging system needs to enhance the visibility of scanned X‑ray TIFF files and archive them as searchable PDF reports for patient records.
 * 2. When a publishing house processes a large collection of scanned manuscript pages in TIFF format, brightens them for readability, and converts each page to PDF for digital distribution.
 * 3. When a construction company digitizes site survey drawings stored as TIFF images, adjusts the brightness to highlight details, and saves them as PDF files for inclusion in project documentation.
 * 4. When an archival project receives batches of historical photographs in TIFF, applies a uniform brightness boost to improve visual quality, and exports the results as PDF for online exhibition.
 * 5. When a legal firm receives scanned contracts as TIFF files, needs to standardize their brightness for consistent review, and converts each contract to PDF for secure electronic filing.
 */