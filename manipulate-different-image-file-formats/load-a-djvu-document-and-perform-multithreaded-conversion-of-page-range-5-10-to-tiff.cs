using System;
using System.IO;
using System.Linq;
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
            string inputPath = @"C:\temp\sample.djvu";
            string outputDirectory = @"C:\temp\output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the DjVu document
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Define page numbers (1‑based) to convert: 5 to 10 inclusive
                int[] pageNumbers = Enumerable.Range(5, 6).ToArray(); // 5,6,7,8,9,10

                // Convert each page in parallel and save as individual TIFF files
                Parallel.ForEach(pageNumbers, pageNumber =>
                {
                    // Zero‑based index for the Pages collection
                    int pageIndex = pageNumber - 1;

                    // Guard against out‑of‑range indexes
                    if (pageIndex < 0 || pageIndex >= djvuImage.Pages.Length)
                        return;

                    // Prepare TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Deflate,
                        BitsPerSample = new ushort[] { 1 } // optional B/W conversion
                    };

                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory, $"page_{pageNumber}.tif");

                    // Ensure the directory for this file exists (unconditional as required)
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
 * 1. When a legal firm needs to extract pages 5‑10 from a scanned DjVu case file and convert them to high‑quality TIFF images for archival in a document management system, this multithreaded C# code speeds up the process.
 * 2. When a publishing company wants to generate printable TIFF proofs of specific chapters stored in a DjVu e‑book, the parallel conversion of pages 5‑10 reduces rendering time on Windows servers.
 * 3. When a medical imaging department receives patient records as DjVu documents and must create lossless TIFF copies of pages 5‑10 for integration with PACS, the code ensures fast, thread‑safe conversion.
 * 4. When a government agency automates the digitization pipeline to transform selected DjVu pages (5‑10) into TIFF files for OCR and searchable archives, the parallel processing improves throughput.
 * 5. When a software vendor builds a batch‑processing tool that extracts a range of DjVu pages (5‑10) and saves them as compressed TIFF files for downstream analysis, this example demonstrates the required C# workflow.
 */