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

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open the DjVu file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Load DjVu image from the stream
                using (DjvuImage djvuImage = new DjvuImage(stream))
                {
                    // Configure TIFF save options with Deflate compression
                    TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                    saveOptions.Compression = TiffCompressions.Deflate;

                    // Enable multi-page saving (all pages will be saved)
                    saveOptions.MultiPageOptions = new DjvuMultiPageOptions();

                    // Save all pages to a single multi-page TIFF file
                    djvuImage.Save(outputPath, saveOptions);
                }
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
 * 1. When a developer needs to convert scanned multi‑page DjVu documents into a single compressed TIFF file for archival or printing workflows, they can use this code to load the DjVu, apply Deflate compression, and save all pages as a multi‑page TIFF.
 * 2. When building a document management system that ingests DjVu files from legacy scanners and must store them in a widely supported TIFF format with lossless compression, this snippet shows how to perform the conversion in C# using Aspose.Imaging.
 * 3. When a legal or medical imaging application requires preserving each page of a DjVu case file while reducing file size for secure transmission, the code demonstrates loading the DjVu stream, setting TiffOptions.Compression to Deflate, and exporting all pages to a single TIFF.
 * 4. When automating batch processing of DjVu ebooks to create searchable TIFF archives, developers can reuse this example to iterate over files, convert each DjVu to a Deflate‑compressed multi‑page TIFF, and save it to a target directory.
 * 5. When integrating Aspose.Imaging into a .NET service that receives DjVu uploads via API and must return a TIFF response with efficient compression, this code provides the necessary steps to read the DjVu from a stream, configure Deflate compression, and output a multi‑page TIFF.
 */