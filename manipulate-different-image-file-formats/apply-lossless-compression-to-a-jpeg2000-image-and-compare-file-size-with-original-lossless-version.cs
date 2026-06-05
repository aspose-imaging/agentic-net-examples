using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\temp\\input.jp2";
            string outputPath = "C:\\temp\\output_compressed.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the original JPEG2000 image
            using (Jpeg2000Image image = new Jpeg2000Image(inputPath))
            {
                // Configure lossless compression options (default is lossless, set explicitly)
                Jpeg2000Options options = new Jpeg2000Options
                {
                    Irreversible = false // use lossless DWT 5-3
                };

                // Save the image with lossless compression
                image.Save(outputPath, options);
            }

            // Compare file sizes
            long originalSize = new FileInfo(inputPath).Length;
            long compressedSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"Compressed size: {compressedSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to archive high‑resolution medical scans in JPEG2000 format while ensuring no diagnostic detail is lost, they can use this code to apply lossless compression and verify the reduced file size.
 * 2. When building a satellite‑imagery processing pipeline in C#, the code helps compress raw JP2 files losslessly before storage, allowing the team to compare original and compressed sizes for storage budgeting.
 * 3. When creating a digital asset management system that stores artwork in JPEG2000, developers can employ this snippet to compress images without quality loss and log the size savings for reporting.
 * 4. When implementing a compliance‑driven document‑archiving solution that requires exact pixel fidelity, the code provides a way to re‑save JP2 files losslessly and confirm they meet size constraints.
 * 5. When optimizing bandwidth for a web service that streams high‑definition JP2 images, developers can use this example to compress images losslessly on the server and compare sizes to decide if further optimization is needed.
 */