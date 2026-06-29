using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Temp\sample.djvu";
            string outputDir = @"C:\Temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Common TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Compression = TiffCompressions.Deflate;
                tiffOptions.BitsPerSample = new ushort[] { 1 };

                // Convert pages 5 through 10 (inclusive) in parallel
                Parallel.For(5, 11, pageIndex =>
                {
                    // Skip if page index is out of range
                    if (pageIndex < 0 || pageIndex >= djvuImage.PageCount)
                        return;

                    string outputPath = Path.Combine(outputDir, $"page_{pageIndex}.tiff");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the specific page as TIFF
                    djvuImage.Pages[pageIndex].Save(outputPath, tiffOptions);
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
 * 1. When a developer must extract pages 5‑10 from a DjVu document and convert them to compressed TIFF files for archival or printing, this multithreaded Aspose.Imaging C# code provides a fast solution.
 * 2. When an application needs to generate searchable TIFF images from a specific page range of a large DjVu file while preserving low‑bit depth, the code uses Aspose.Imaging’s TiffOptions with Deflate compression.
 * 3. When a batch‑processing service has to convert multiple DjVu pages to TIFF in parallel to reduce CPU time on a server, the Parallel.For loop in the example handles concurrent page conversion.
 * 4. When a document‑management system requires on‑demand conversion of selected DjVu pages to TIFF for downstream OCR or indexing, this snippet demonstrates how to load the DjVu stream, validate page indices, and save each page as a TIFF image.
 * 5. When a developer needs to ensure the output directory structure exists and safely process a DjVu file’s page range without exceeding its page count, the code’s file‑system checks and page‑range validation make the conversion reliable.
 */