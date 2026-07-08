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
            // Hard‑coded input and output directories
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Ensure the output directory exists (will also handle subfolders)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
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

                // Load the TIFF image
                using (Image image = Image.Load(filePath))
                {
                    // Cast to TiffImage to access AdjustContrast
                    TiffImage tiffImage = (TiffImage)image;

                    // Increase contrast (value in range [-100, 100])
                    tiffImage.AdjustContrast(50f);

                    // Build the output PDF path (same file name, .pdf extension)
                    string outputFileName = Path.GetFileNameWithoutExtension(filePath) + ".pdf";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PDF using PdfOptions
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
 * 1. When a medical imaging system needs to batch‑convert scanned radiology TIFF files into high‑contrast PDFs for easier review by clinicians.
 * 2. When an archival project must enhance the readability of historical document scans stored as TIFFs and generate searchable PDF versions for a digital library.
 * 3. When a printing workflow requires automatically increasing the contrast of product catalog TIFF images before creating PDF proofs for quality control.
 * 4. When a legal firm wants to preprocess large sets of TIFF‑based evidence photos by boosting contrast and packaging them as PDFs for courtroom presentation.
 * 5. When a GIS application needs to prepare satellite TIFF tiles with improved contrast and export them as PDFs for inclusion in mapping reports.
 */