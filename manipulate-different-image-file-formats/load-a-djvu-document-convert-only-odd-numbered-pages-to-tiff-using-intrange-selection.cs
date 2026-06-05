using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input\\sample.djvu";
            string outputPath = "output\\odd_pages.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Collect indexes of odd-numbered pages (1‑based numbering)
                List<int> oddPageIndexes = new List<int>();
                for (int i = 0; i < djvuImage.PageCount; i++)
                {
                    // i = 0 corresponds to page 1
                    if ((i % 2) == 0)
                    {
                        oddPageIndexes.Add(i);
                    }
                }

                // Set up TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 }; // optional B/W conversion
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(oddPageIndexes.ToArray());

                // Save selected pages to TIFF
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a legal firm needs to archive only the odd‑numbered pages of scanned case files stored as DjVu into a searchable multi‑page TIFF for compliance, this C# Aspose.Imaging code performs the conversion.
 * 2. When a publishing house wants to extract every other page from a DjVu manuscript to create a low‑resolution preview TIFF for reviewers, the example shows how to select odd pages with IntRange and save them as a compressed TIFF.
 * 3. When a medical records system must convert patient charts saved in DjVu format to black‑and‑white TIFFs while keeping only the odd pages that contain diagnostic images, this code provides the necessary page‑filtering and compression steps.
 * 4. When an archival project requires batch processing of DjVu documents to generate multi‑page TIFFs that include only the odd‑numbered pages for reduced storage size, developers can apply the shown DjvuMultiPageOptions in C#.
 * 5. When a desktop application needs to load a DjVu file, programmatically identify pages 1, 3, 5, etc., and export them as a deflate‑compressed TIFF for integration with OCR pipelines, the provided snippet illustrates the complete workflow.
 */