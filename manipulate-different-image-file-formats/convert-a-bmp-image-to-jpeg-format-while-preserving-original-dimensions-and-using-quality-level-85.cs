using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BmpToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output file paths
                string inputPath = @"C:\temp\input.bmp";
                string outputPath = @"C:\temp\output.jpg";

                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG save options with quality 85
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 85
                    };

                    // Save the image as JPEG preserving original dimensions
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to batch‑convert legacy BMP screenshots to smaller JPEG files for faster web uploads while keeping the original width and height and a quality setting of 85.
 * 2. When an automated reporting tool generates charts as BMP images and must save them as JPEGs to embed in email attachments without distorting the image size.
 * 3. When a migration script moves user‑uploaded BMP avatars to a JPEG format to reduce storage costs, preserving the exact pixel dimensions and applying a consistent quality level.
 * 4. When a C# service processes scanned documents saved as BMP and converts them to JPEG for compatibility with third‑party image viewers, ensuring the output dimensions match the source.
 * 5. When a Windows service monitors a folder of BMP assets and needs to create JPEG thumbnails with the same dimensions and a quality of 85 for use in a mobile app’s gallery.
 */