using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.jp2";

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

            // Load the PNG image
            using (PngImage pngImage = (PngImage)Image.Load(inputPath))
            {
                // Configure JPEG2000 options for lossless compression and buffer size hint
                Jpeg2000Options jpeg2000Options = new Jpeg2000Options
                {
                    // Irreversible = false (default) ensures lossless DWT 5-3 compression
                    Irreversible = false,
                    // Example buffer size hint (in bytes)
                    BufferSizeHint = 2 * 1024 * 1024 // 2 MB
                };

                // Save as JPEG2000 using the configured options
                pngImage.Save(outputPath, jpeg2000Options);
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
 * 1. When a developer needs to convert high‑resolution PNG assets to lossless JPEG2000 for archival storage while controlling memory usage with a buffer size hint.
 * 2. When an application must generate JPEG2000 files from PNG graphics for web services that require lossless compression to preserve image quality during transmission.
 * 3. When a batch‑processing tool has to transform PNG scans into JPEG2000 format to meet DICOM medical imaging standards without introducing compression artifacts.
 * 4. When a desktop utility needs to create JPEG2000 thumbnails from PNG source images while ensuring the process stays within a 2 MB memory buffer.
 * 5. When a cloud‑based image pipeline must convert PNG uploads to JPEG2000 with lossless DWT compression and explicit buffer limits to avoid out‑of‑memory errors.
 */