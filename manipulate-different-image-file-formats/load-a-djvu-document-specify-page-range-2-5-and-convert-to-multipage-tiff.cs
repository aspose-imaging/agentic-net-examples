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
            string inputPath = @"C:\temp\sample.djvu";
            string outputPath = @"C:\temp\sample.tif";

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
                // Prepare TIFF save options
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                saveOptions.Compression = TiffCompressions.Deflate;
                // Convert to 1‑bit B/W if needed
                saveOptions.BitsPerSample = new ushort[] { 1 };

                // Specify page range 2‑5 (inclusive)
                saveOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(2, 5));

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
 * 1. When a developer needs to extract pages 2‑5 from a multi‑page DjVu file and archive them as a compressed 1‑bit black‑and‑white multipage TIFF for long‑term storage.
 * 2. When a document‑management system must convert a selected range of DjVu pages into a TIFF format that supports Deflate compression and is compatible with legacy scanning workflows.
 * 3. When a legal‑tech application requires converting specific pages of a DjVu case file into a searchable multipage TIFF while preserving high‑contrast B/W rendering for OCR preprocessing.
 * 4. When an e‑learning platform wants to generate printable handouts by taking pages 2‑5 from a DjVu textbook and saving them as a single TIFF file that can be easily printed or embedded in PDFs.
 * 5. When a batch‑processing script automates the migration of archived DjVu documents to a standardized TIFF archive, needing to process only certain pages and apply 1‑bit compression to meet archival standards.
 */