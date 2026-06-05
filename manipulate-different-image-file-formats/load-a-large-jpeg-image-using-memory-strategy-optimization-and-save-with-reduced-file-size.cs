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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG with a memory‑usage hint (e.g., 100 MB)
            var loadOptions = new LoadOptions { BufferSizeHint = 100 };
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Configure JPEG save options to reduce file size
                var saveOptions = new JpegOptions
                {
                    Quality = 60, // lower quality reduces size
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
 * 1. When a web application must display a high‑resolution JPEG uploaded by users but needs to limit server memory usage, a developer can load the image with Aspose.Imaging’s BufferSizeHint and save it with lower quality and progressive compression.
 * 2. When a desktop photo‑management tool processes large camera‑generated JPEG files and wants to create smaller preview versions without loading the entire image into RAM, this code shows how to use a memory‑strategy hint and re‑save the image efficiently.
 * 3. When an automated batch‑processing service archives thousands of product photos and must keep the archive size low, a developer can read each large JPEG with a 100 MB buffer and re‑save it at reduced quality to shrink file size.
 * 4. When a mobile‑backend API receives high‑resolution JPEGs from smartphones and needs to reduce bandwidth before delivering them to clients, the snippet demonstrates loading the image with memory‑optimized options and exporting it as a progressive JPEG with a smaller footprint.
 * 5. When a digital‑asset‑management system must ensure incoming JPEGs fit within a memory budget while creating space‑efficient copies for long‑term storage, this example provides the exact steps to load the image with a buffer hint and save it with lower quality and progressive compression.
 */