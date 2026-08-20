// HOW-TO: Convert PNG to JPEG with 95 Quality Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options with quality set to 95%
                var jpegOptions = new JpegOptions
                {
                    Quality = 95
                };

                // Save the image as JPEG using the configured options
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce file size of high‑resolution PNG assets for web pages by converting them to JPEG with a specific 95 % quality setting.
 * 2. When an automated batch process must generate JPEG thumbnails from PNG source images while preserving visual fidelity.
 * 3. When a desktop application requires saving user‑uploaded PNG pictures as JPEG files with controlled compression for email attachment limits.
 * 4. When a migration script moves legacy PNG graphics to a JPEG‑based catalog and must enforce a consistent quality level.
 * 5. When a reporting tool exports charts created as PNG into JPEG format to ensure compatibility with third‑party viewers that only support JPEG.
 */
