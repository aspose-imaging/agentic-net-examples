using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\large_input.jpg";
            string outputPath = @"C:\Images\large_output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG with a memory‑usage hint (e.g., 100 MB max for internal buffers)
            var loadOptions = new LoadOptions { BufferSizeHint = 100 };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure JPEG save options to reduce file size
                var saveOptions = new JpegOptions
                {
                    Quality = 70, // lower quality → smaller file
                    CompressionType = JpegCompressionMode.Progressive // progressive JPEG often yields better compression
                };

                // Save the processed image
                image.Save(outputPath, saveOptions);
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
 * 1. When a web application must upload a high‑resolution JPEG from a user's device but needs to limit server memory consumption, the code can load the image with a 100 MB buffer hint and save a smaller progressive JPEG.
 * 2. When a desktop batch‑processing tool processes thousands of large product photos for an e‑commerce catalog, this snippet ensures each image is loaded efficiently and saved with reduced quality to meet bandwidth constraints.
 * 3. When a mobile backend service receives camera‑generated JPEGs that exceed available RAM, developers can use the BufferSizeHint and JpegOptions to down‑sample and compress the files before storing them.
 * 4. When an automated reporting system generates large JPEG charts that must be archived, the code helps keep the archive size low by converting the images to progressive JPEGs with a configurable quality level.
 * 5. When a cloud‑based image‑optimization pipeline needs to handle big JPEG uploads without exhausting VM memory, the example demonstrates how to load the image with a memory‑usage hint and output a smaller file for faster CDN delivery.
 */