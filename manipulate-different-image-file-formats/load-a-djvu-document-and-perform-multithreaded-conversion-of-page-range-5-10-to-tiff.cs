using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.djvu";
        string outputDirectory = @"C:\Temp\output";

        // Path safety checks
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

        try
        {
            // Load DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define page range 5‑10 (inclusive)
                var pageIndices = Enumerable.Range(5, 6); // 5,6,7,8,9,10

                // Process each page in parallel
                Parallel.ForEach(pageIndices, pageIndex =>
                {
                    // Retrieve the specific page
                    var djvuPage = djvuImage.DjvuPages[pageIndex];

                    // Configure TIFF save options
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Deflate,
                        BitsPerSample = new ushort[] { 1 } // B/W conversion
                    };

                    // Build output file path for this page
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.tif");

                    // Ensure directory exists (already created above)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as TIFF
                    djvuPage.Save(outputPath, tiffOptions);
                });
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
 * 1. When a legal firm needs to extract pages 5‑10 from a scanned DjVu case file and store them as high‑compression TIFF images for archival in a document management system.
 * 2. When a publishing company wants to generate black‑and‑white TIFF previews of specific pages from a DjVu manuscript to embed in an online catalog.
 * 3. When a medical records department must convert selected pages of a DjVu patient scan into TIFF format with Deflate compression for integration with a PACS system.
 * 4. When a government agency automates the batch processing of DjVu land‑registry documents, converting pages 5‑10 to TIFF for OCR processing on a multi‑core server.
 * 5. When an educational platform extracts a range of DjVu textbook pages to create TIFF assets for offline e‑reader apps while leveraging parallel execution to speed up conversion.
 */