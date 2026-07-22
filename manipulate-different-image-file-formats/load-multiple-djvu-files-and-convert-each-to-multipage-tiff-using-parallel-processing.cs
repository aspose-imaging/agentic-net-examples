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
            // Hard‑coded list of DjVu files to process
            string[] inputFiles = new string[]
            {
                @"C:\Data\sample1.djvu",
                @"C:\Data\sample2.djvu",
                @"C:\Data\sample3.djvu"
            };

            // Output directory for the generated TIFF files
            string outputDirectory = @"C:\Data\Converted";

            // Process each file in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output file path
                string outputPath = Path.Combine(
                    outputDirectory,
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

                    // Save the DjVu image as a multipage TIFF
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
 * 1. When a digital archiving system needs to batch‑convert scanned DjVu documents into searchable multipage TIFF files for long‑term storage while leveraging Parallel.ForEach to maximize CPU usage.
 * 2. When a legal firm must quickly transform a collection of DjVu case files into multipage TIFFs to comply with court‑required image formats and preserve page order using parallel processing in C#.
 * 3. When a publishing workflow requires converting multiple DjVu chapters into high‑compression TIFF stacks for inclusion in print‑ready PDFs, taking advantage of Aspose.Imaging’s TiffOptions and parallel execution.
 * 4. When a medical imaging application needs to import several DjVu patient records and export them as multipage TIFFs for integration with PACS systems, using C# parallel loops to speed up the process.
 * 5. When a cloud‑based document processing service wants to parallelize the conversion of user‑uploaded DjVu files to multipage TIFFs to reduce latency and improve throughput in a .NET environment.
 */