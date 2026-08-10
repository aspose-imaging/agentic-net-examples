// HOW-TO: Batch Convert Up To 30 DjVu Files To Multi-Page TIFF In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Get all DjVu files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.djvu");

            int processed = 0;
            foreach (string inputPath in files)
            {
                if (processed >= 30)
                    break;

                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the DjVu document and save it as a multi‑page TIFF
                using (FileStream stream = File.OpenRead(inputPath))
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    // Export all pages; an empty constructor selects the whole document
                    tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    djvuImage.Save(outputPath, tiffOptions);
                }

                processed++;
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
 * 1. When you need to archive a collection of scanned documents stored as DjVu into a single multi-page TIFF for compatibility with legacy systems.
 * 2. When a batch processing job must convert a large set of DjVu images to TIFF for printing or OCR pipelines without manual intervention.
 * 3. When you want to automate the migration of DjVu e-books to TIFF format to support applications that only read TIFF files.
 * 4. When a server-side service processes incoming DjVu uploads and saves them as TIFFs for downstream image analysis.
 * 5. When you need to limit conversion to the first 30 DjVu files in a folder to control resource usage during bulk conversion.
 */
