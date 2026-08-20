// HOW-TO: How To Save BMP As High Compression JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output_high_compression.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options for high compression (low quality)
                JpegOptions saveOptions = new JpegOptions
                {
                    // Very low quality value (1‑100) results in strong compression
                    Quality = 10,

                    // Use progressive compression to further reduce size (optional)
                    CompressionType = JpegCompressionMode.Progressive,

                    // Keep other defaults (bits per channel, resolution, etc.)
                };

                // Save the image with the specified JPEG options
                image.Save(outputPath, saveOptions);
            }

            // Inform the user that the operation completed
            Console.WriteLine($"Image saved with high compression to: {outputPath}");
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the file size of large BMP screenshots for faster web page loading, you can convert them to a low‑quality JPEG using Aspose.Imaging in C#.
 * 2. When preparing product images for email newsletters where bandwidth is limited, this code lets you compress BMP files into small JPEG attachments.
 * 3. When archiving legacy BMP assets on a server with storage constraints, you can shrink them by saving as high‑compression JPEGs programmatically.
 * 4. When generating thumbnails for a mobile app that requires minimal data transfer, the snippet converts BMP source images to progressive JPEGs with low quality.
 * 5. When automating batch processing of scanned documents to meet upload size limits of a cloud service, the example shows how to apply aggressive JPEG compression in C#.
 */
