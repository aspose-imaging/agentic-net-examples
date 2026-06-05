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
        // Hardcoded input and output paths
        string inputPath = "./input.djvu";
        string outputPath = "./output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document from file stream
            using (Stream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options with Deflate compression
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Deflate;

                // Use default MultiPageOptions to export all pages
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

                // Save all pages as a multi‑page TIFF file
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
 * 1. When a developer needs to convert scanned DjVu archives into a single multi‑page TIFF file with Deflate compression for archival storage and easier viewing in standard image viewers.
 * 2. When a developer wants to batch‑process DjVu documents from a file system and generate compressed TIFF files that can be indexed by document management systems.
 * 3. When a developer is building a .NET service that receives DjVu uploads, compresses them using Deflate TIFF compression, and returns a multi‑page TIFF for downstream OCR pipelines.
 * 4. When a developer must ensure that all pages of a DjVu e‑book are preserved in a lossless‑compatible TIFF format for printing or publishing workflows.
 * 5. When a developer needs to validate the existence of a DjVu file, create the output directory, and safely stream the conversion to TIFF with custom compression to avoid memory overload.
 */