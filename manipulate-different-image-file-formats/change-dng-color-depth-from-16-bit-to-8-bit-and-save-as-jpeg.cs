// HOW-TO: Convert 16‑Bit DNG To 8‑Bit JPEG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.dng";
            string outputPath = @"c:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage to access DNG‑specific members if needed
                DngImage dngImage = (DngImage)image;

                // Prepare JPEG options (default will convert to 8‑bit per channel)
                JpegOptions jpegOptions = new JpegOptions
                {
                    // Optional: set quality (0‑100)
                    Quality = 90
                };

                // Save as JPEG; Aspose.Imaging handles conversion from 16‑bit to 8‑bit automatically
                dngImage.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce the file size of high‑resolution raw photos for web display by converting 16‑bit DNG files to standard 8‑bit JPEGs in a C# application.
 * 2. When integrating a photo‑processing pipeline that must accept raw camera images and output JPEGs compatible with browsers or mobile devices.
 * 3. When automating batch conversion of raw DNG files to JPEG while preserving color fidelity by letting Aspose.Imaging handle the bit‑depth reduction.
 * 4. When building a desktop tool that validates the existence of raw files, creates output folders, and safely converts them to JPEG with configurable quality.
 * 5. When you want to catch and log errors during image loading or saving to ensure robust handling of corrupted or missing DNG files.
 */
