using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.djvu";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load DjVu document
            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Specify page range 2‑5 (zero‑based indexes)
                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions();
                multiPageOptions.Pages = new int[] { 2, 3, 4, 5 };
                tiffOptions.MultiPageOptions = multiPageOptions;

                // Save as multipage TIFF
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
 * 1. When a legal firm needs to extract pages 2‑5 from a scanned DjVu case file and archive them as a single multipage TIFF for compatibility with their document management system.
 * 2. When a publishing company wants to create a preview TIFF booklet containing only the middle chapters (pages 2‑5) of a DjVu manuscript before sending it to reviewers.
 * 3. When a medical records department must convert selected pages of a DjVu radiology report into a multipage TIFF to embed into a patient’s electronic health record.
 * 4. When an archival project requires batch processing of DjVu historical documents, extracting a specific page range and saving them as a TIFF stack for long‑term preservation.
 * 5. When a GIS analyst needs to isolate map sections on pages 2‑5 of a DjVu survey and convert them into a multipage TIFF for further analysis in imaging software.
 */