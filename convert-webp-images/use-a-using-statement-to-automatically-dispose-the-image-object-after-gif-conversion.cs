using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.gif";
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

            // Load the GIF image and automatically dispose it after conversion
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as PNG using default options
                image.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web application needs to convert user‑uploaded animated GIFs to static PNG thumbnails while ensuring the Image object is released automatically with a using statement.
 * 2. When a batch processing script must transform a directory of GIF assets into PNG files for a mobile app that only supports PNG, and wants deterministic disposal of unmanaged resources.
 * 3. When an e‑commerce platform generates product preview images by converting promotional GIF banners to PNG format to improve loading speed and avoid memory leaks.
 * 4. When a desktop utility reads a GIF file, saves it as PNG for archival purposes, and relies on the using block to guarantee the image file handle is closed even if an exception occurs.
 * 5. When a cloud‑based image service receives a GIF via API, converts it to PNG for downstream processing, and uses the using statement to automatically clean up the Aspose.Imaging Image instance.
 */