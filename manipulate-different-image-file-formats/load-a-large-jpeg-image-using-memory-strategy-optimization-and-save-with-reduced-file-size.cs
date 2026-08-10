// HOW-TO: Load Large JPEG with Memory Buffer Hint and Save Optimized Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\large.jpg";
        string outputPath = @"C:\temp\large_optimized.jpg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG with a memory‑usage hint (e.g., 100 MB buffer limit)
            var loadOptions = new LoadOptions { BufferSizeHint = 100 };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure JPEG save options to reduce file size
                var saveOptions = new JpegOptions
                {
                    // Lower quality (1‑100) reduces size; 60 is a typical trade‑off
                    Quality = 60,
                    // Use progressive compression for better web loading
                    CompressionType = JpegCompressionMode.Progressive
                };

                // Save the optimized image
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

/*
 * Real-World Use Cases:
 * 1. When you need to display a high‑resolution photo on a website but must keep the download size low, you can load the JPEG with a buffer limit and save it with reduced quality and progressive compression.
 * 2. When processing large image files on a server with limited RAM, the memory‑usage hint prevents out‑of‑memory errors while still allowing you to create a smaller version for thumbnails.
 * 3. When preparing images for email attachments, this code lets you shrink the JPEG file size without changing the format, ensuring the attachment stays under size limits.
 * 4. When automating a batch job that converts legacy high‑quality JPEGs to web‑friendly versions, the approach guarantees consistent quality settings and efficient memory handling.
 * 5. When integrating image optimization into a C# desktop application that uploads photos to a cloud service, the code reduces bandwidth by saving a compressed JPEG with progressive encoding.
 */
