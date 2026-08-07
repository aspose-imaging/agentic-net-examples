using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.djvu";
        string outputDir = @"c:\temp\output";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates if missing)
            Directory.CreateDirectory(outputDir);

            // Open the DjVu file as a stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Prepare TIFF save options with LZW compression
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Lzw;

                    // Iterate through each page and save as separate TIFF
                    foreach (DjvuPage djvuPage in djvuImage.Pages)
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDir, $"sample.{djvuPage.PageNumber}.tif");

                        // Ensure the directory for the output file exists (already created above)
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as TIFF using the specified options
                        djvuPage.Save(outputPath, tiffOptions);
                    }
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
 * 1. When a legal firm needs to convert scanned DjVu case files into lossless TIFF images with LZW compression for archival in a document management system.
 * 2. When a publishing company wants to split a multi‑page DjVu manuscript into individual TIFF pages for high‑quality print proofs.
 * 3. When a government agency must transform DjVu maps into separate TIFF tiles to feed into GIS software that only accepts TIFF input.
 * 4. When a medical records department requires each page of a DjVu patient chart to be saved as a compressed TIFF for secure electronic health record storage.
 * 5. When an e‑learning platform extracts DjVu lecture slides into individual TIFF files to generate thumbnails and support offline viewing.
 */