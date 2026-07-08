using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
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

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Set PNG save options (default options are sufficient)
                var pngOptions = new PngOptions();

                // Save the image in PNG format
                image.Save(outputPath, pngOptions);
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
 * 1. When a desktop application needs to batch‑convert legacy BMP files to PNG for web upload while ensuring unmanaged memory is released after each conversion.
 * 2. When an automated build script processes scanned documents stored as BMP and saves them as lossless PNG to reduce file size without leaking resources.
 * 3. When a Windows service monitors a folder, converts newly added BMP images to PNG for downstream processing, and must dispose the Image object to avoid memory leaks.
 * 4. When a C# utility prepares product screenshots in BMP format for inclusion in a mobile app by converting them to PNG and ensuring the image handle is closed promptly.
 * 5. When a server‑side API receives BMP uploads, converts them to PNG for storage, and needs to free unmanaged resources to maintain high concurrency.
 */