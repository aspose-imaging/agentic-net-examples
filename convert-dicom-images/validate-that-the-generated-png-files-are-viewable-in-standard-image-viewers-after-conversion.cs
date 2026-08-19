// HOW-TO: Convert BMP to PNG and Verify Output Is Viewable in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output file paths
            string inputPath = @"C:\temp\sample.bmp";
            string outputPath = @"C:\temp\output.png";

            // Verify the source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any supported format)
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default PNG options
                image.Save(outputPath, new PngOptions());
            }

            // Validate that the saved PNG can be loaded (viewable in standard viewers)
            if (Image.CanLoad(outputPath))
            {
                Console.WriteLine("PNG file saved and verified successfully.");
            }
            else
            {
                Console.Error.WriteLine("Saved PNG file could not be loaded.");
            }
        }
        catch (Exception ex)
        {
            // Catch any unexpected errors and report them
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to transform legacy BMP assets to PNG for web delivery while ensuring the resulting files can be opened by standard image viewers.
 * 2. When an automated batch process must create PNG thumbnails from various source formats and confirm each thumbnail is valid before publishing.
 * 3. When integrating image conversion into a C# application that must guarantee the saved PNG files are not corrupted and can be re‑loaded for further processing.
 * 4. When preparing images for a reporting system that only accepts PNG, and you want to programmatically verify the conversion succeeded.
 * 5. When migrating a file repository from BMP to PNG and you require a quick sanity check that each converted file is readable by typical viewer software.
 */
