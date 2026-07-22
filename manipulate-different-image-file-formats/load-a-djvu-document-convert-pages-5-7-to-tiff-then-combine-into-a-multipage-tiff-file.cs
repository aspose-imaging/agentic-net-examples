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
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load DjVu document from file stream
            using (FileStream stream = File.OpenRead(inputPath))
            using (DjvuImage djvuImage = new DjvuImage(stream))
            {
                // Configure TIFF save options for multi‑page output
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Deflate,
                    BitsPerSample = new ushort[] { 1 },
                    MultiPageOptions = new DjvuMultiPageOptions(new int[] { 4, 5, 6 }) // pages 5‑7 (zero‑based)
                };

                // Optional: set page titles
                tiffOptions.MultiPageOptions.PageTitles = new string[] { "Page 5", "Page 6", "Page 7" };

                // Save selected pages as a single multipage TIFF file
                djvuImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer must extract pages 5‑7 from a DjVu file and generate a single multipage TIFF for archival storage or document management systems.
 * 2. When an application needs to convert selected DjVu pages into a compressed (Deflate) TIFF while preserving 1‑bit binary image data for OCR preprocessing.
 * 3. When a workflow requires programmatically adding page titles to a multipage TIFF created from a DjVu source to improve navigation in imaging viewers.
 * 4. When a .NET service processes scanned books in DjVu format and needs to deliver only a subset of pages as a TIFF bundle to downstream printing or publishing pipelines.
 * 5. When a developer wants to verify the input DjVu file, ensure the output directory exists, and safely handle exceptions while converting specific pages to a TIFF using Aspose.Imaging.
 */