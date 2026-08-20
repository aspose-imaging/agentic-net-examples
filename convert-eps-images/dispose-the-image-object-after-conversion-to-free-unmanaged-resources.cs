// HOW-TO: Convert JPEG to PNG and Dispose Image in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output.png";

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

            // Load the image, convert, and save
            using (Image image = Image.Load(inputPath))
            {
                // Define save options (PNG in this example)
                PngOptions saveOptions = new PngOptions();

                // Save the image to the output path
                image.Save(outputPath, saveOptions);
            } // Image is disposed here
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert user‑uploaded JPEG photos to PNG format for web display while ensuring the Image object is properly disposed to free unmanaged memory.
 * 2. When a desktop application must generate lossless PNG thumbnails from existing JPEG files without leaking resources.
 * 3. When an automated batch job processes a folder of JPEG images and saves them as PNG files, using a using block to guarantee cleanup.
 * 4. When a server‑side API receives a JPEG image, converts it to PNG for downstream processing, and must release the Aspose.Imaging resources promptly.
 * 5. When integrating Aspose.Imaging into a C# utility that validates input files, creates the output directory, and safely converts and saves images with proper disposal.
 */
