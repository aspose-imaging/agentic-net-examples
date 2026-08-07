using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\test.webp";
        string outputPath = @"c:\temp\output\test.output.png";

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

            // Load the WebP image from the input path
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Save the image as PNG using PngOptions
                webPImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a Blazor WebAssembly app needs to convert user‑uploaded WebP photos to PNG for display in browsers that do not support WebP, a developer can use this code to perform the conversion client‑side.
 * 2. When an e‑commerce site wants to let customers upload product images in WebP and store them as PNG thumbnails in a secure folder, this snippet shows how to validate the file, create the output directory, and save the PNG using Aspose.Imaging.
 * 3. When a social media platform requires client‑side image processing to reduce server load by converting uploaded WebP avatars to PNG before sending them to the backend, the code demonstrates the necessary C# file‑system checks and image format conversion.
 * 4. When a document management system needs to ensure that all scanned documents are saved as lossless PNG files, developers can use this example to load WebP scans and export them with PngOptions in a .NET Blazor app.
 * 5. When a photo‑editing web app offers a “Save as PNG” feature for images originally captured in WebP, this code provides the straightforward approach to load the WebP image, verify its existence, and write the PNG output to a user‑specified folder.
 */