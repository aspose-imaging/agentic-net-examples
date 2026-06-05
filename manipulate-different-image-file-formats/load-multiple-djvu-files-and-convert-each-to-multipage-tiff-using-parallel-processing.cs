using System;
using System.IO;
using System.Threading.Tasks;
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
            // Hardcoded list of DjVu files to convert
            string[] inputFiles = new string[]
            {
                @"C:\Input\doc1.djvu",
                @"C:\Input\doc2.djvu",
                @"C:\Input\doc3.djvu"
            };

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine the output TIFF path (same folder, same name with .tif extension)
                string outputPath = Path.ChangeExtension(inputPath, ".tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DjVu document and save it as a multipage TIFF
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Compression = TiffCompressions.Deflate;
                    // Optional: set 1-bit per sample for B/W conversion
                    tiffOptions.BitsPerSample = new ushort[] { 1 };
                    // Enable multipage export
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    // Save the DjVu image as a multipage TIFF
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
 * 1. When a document management system needs to batch‑convert archived DjVu scans into searchable multipage TIFF files for archival storage, a developer can use this C# code with Aspose.Imaging to process many files in parallel.
 * 2. When a legal firm wants to quickly transform a collection of DjVu case files into high‑compression, 1‑bit per sample TIFF images for e‑discovery platforms, the parallel conversion routine speeds up the workflow.
 * 3. When an OCR pipeline requires input as multipage TIFFs but the source documents are supplied as DjVu, developers can employ this code to load each DjVu, apply Deflate compression, and save as TIFF in a single pass.
 * 4. When a cloud‑based image service must generate TIFF previews for multiple DjVu ebooks simultaneously to improve user download times, the Parallel.ForEach approach distributes the workload across CPU cores.
 * 5. When a batch‑processing job needs to ensure that output directories exist and handle missing DjVu files gracefully while converting each document to a compressed multipage TIFF, this example provides the necessary error handling and file‑system logic.
 */