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
            // Hardcoded list of DjVu files to process
            string[] inputFiles = new string[]
            {
                @"C:\Images\doc1.djvu",
                @"C:\Images\doc2.djvu",
                @"C:\Images\doc3.djvu"
            };

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output TIFF file path (same folder, same name with .tif extension)
                string outputPath = Path.ChangeExtension(inputPath, ".tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DjVu document from a file stream
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options for multi‑page output
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;
                    // Example: force 1‑bit per sample (B/W) conversion
                    tiffOptions.BitsPerSample = new ushort[] { 1 };
                    // Enable multi‑page export
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    // Save the DjVu document as a multi‑page TIFF file
                    djvuImage.Save(outputPath, tiffOptions);
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a legal firm needs to batch‑convert archived DjVu case files into searchable multi‑page TIFFs for integration with their document‑management system, they can use this parallel C# code to speed up the process.
 * 2. When a publishing company must transform a collection of scanned DjVu manuscripts into high‑resolution multi‑page TIFFs for print‑ready workflows, the code enables fast, simultaneous conversions on a multi‑core server.
 * 3. When a government agency automates the migration of historic DjVu maps into compressed 1‑bit TIFF archives for long‑term storage, the parallel processing loop reduces overall conversion time.
 * 4. When an e‑learning platform prepares course materials by converting multiple DjVu lecture slides into multi‑page TIFFs that can be displayed in web viewers, this code handles the bulk conversion efficiently.
 * 5. When a medical records system needs to batch‑process patient DjVu scans into multi‑page TIFFs with Deflate compression for secure archival, the parallelized C# routine ensures rapid, reliable output.
 */