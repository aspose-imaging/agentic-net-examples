using System;
using System.IO;
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
            // Hardcoded input and output paths
            string inputPath = "input.djvu";
            string outputPath = "output\\result.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Prepare TIFF save options with default settings
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions(); // all pages will be saved

                // Save as multipage TIFF
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
 * 1. When a C# application must archive multi‑page DjVu manuals as a single multipage TIFF file for long‑term storage or compliance auditing.
 * 2. When a developer needs to convert scanned DjVu invoices into a TIFF format that can be easily indexed by enterprise document management systems.
 * 3. When an image‑processing pipeline requires transforming DjVu e‑books into multipage TIFFs before applying OCR or printing workflows.
 * 4. When a Windows service automates the migration of legacy DjVu technical drawings to TIFF for compatibility with legacy CAD viewers.
 * 5. When a .NET web service generates downloadable multipage TIFF reports from user‑uploaded DjVu files using default Aspose.Imaging options.
 */