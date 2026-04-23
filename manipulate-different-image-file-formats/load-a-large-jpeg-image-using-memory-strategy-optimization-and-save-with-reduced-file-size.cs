using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\large.jpg";
        string outputPath = @"C:\temp\large_optimized.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG with a memory‑usage hint (e.g., 100 MB)
            var loadOptions = new LoadOptions { BufferSizeHint = 100 };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure JPEG save options to reduce file size
                var saveOptions = new JpegOptions
                {
                    // Lower quality reduces size (range 1‑100)
                    Quality = 60,
                    // Use progressive compression for better web loading
                    CompressionType = JpegCompressionMode.Progressive,
                    // Optional: reduce bits per channel if acceptable
                    BitsPerChannel = 8
                };

                // Save the optimized JPEG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}