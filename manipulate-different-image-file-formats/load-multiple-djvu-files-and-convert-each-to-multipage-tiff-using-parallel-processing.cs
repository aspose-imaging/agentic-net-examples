// HOW-TO: Convert Multiple DjVu Files To Multipage TIFF In Parallel With C# (Aspose.Imaging for .NET)
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
            // Hardcoded input DjVu files
            string[] inputFiles = new[]
            {
                @"C:\Images\Input1.djvu",
                @"C:\Images\Input2.djvu",
                @"C:\Images\Input3.djvu"
            };

            // Hardcoded output directory
            string outputDirectory = @"C:\Images\Output";

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path (same name with .tif extension)
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".tif");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load DjVu document and save as multipage TIFF
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = DjvuImage.LoadDocument(stream))
                {
                    // Configure TIFF save options
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        Compression = TiffCompressions.Deflate,
                        BitsPerSample = new ushort[] { 1 },
                        MultiPageOptions = new DjvuMultiPageOptions()
                    };

                    // Save the multipage TIFF
                    djvuImage.Save(outputPath, saveOptions);
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
 * 1. When a company needs to batch‑convert scanned DjVu archives into searchable multipage TIFFs for long‑term storage while maximizing CPU utilization.
 * 2. When a document‑management system must ingest dozens of DjVu reports and store them as compressed TIFF files that can be opened by standard image viewers.
 * 3. When a developer wants to speed up conversion of large DjVu collections by processing each file on a separate thread using Parallel.ForEach.
 * 4. When an automated workflow requires converting DjVu e‑books into multipage TIFFs with Deflate compression to reduce file size before uploading to a cloud repository.
 * 5. When a legal‑tech application must transform multiple DjVu evidence files into multipage TIFFs to preserve page order and enable OCR processing later.
 */
