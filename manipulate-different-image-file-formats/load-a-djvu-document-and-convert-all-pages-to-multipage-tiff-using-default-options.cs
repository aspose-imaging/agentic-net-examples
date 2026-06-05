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
        string outputPath = @"c:\temp\sample.tif";

        // Check input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu image from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options with default settings
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions(); // all pages will be saved

                // Save all pages as a multipage TIFF
                djvuImage.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to archive scanned DjVu documents into a single multipage TIFF for compatibility with legacy document management systems.
 * 2. When an application must batch‑convert multi‑page DjVu reports into a TIFF format that can be opened by standard image viewers without losing page order.
 * 3. When a .NET service processes user‑uploaded DjVu ebooks and creates a multipage TIFF version for printing or OCR pipelines.
 * 4. When a workflow automates the migration of archival DjVu assets to TIFF to meet regulatory requirements that only accept TIFF images.
 * 5. When a developer integrates Aspose.Imaging in a C# utility to read DjVu streams and output a default‑configured multipage TIFF for downstream image analysis tools.
 */