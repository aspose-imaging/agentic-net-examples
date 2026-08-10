// HOW-TO: Create 150x150 JPEG Thumbnail From EPS Image In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Resize to 150x150 pixels using Lanczos resampling
                image.Resize(150, 150, ResizeType.LanczosResample);

                // Save as JPEG
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to display a small preview of a vector EPS logo on a web page, you can generate a 150×150 JPEG thumbnail with Aspose.Imaging.
 * 2. When an e‑commerce platform stores product drawings as EPS files but requires fast‑loading thumbnail images for search results, this code creates the required JPEG previews.
 * 3. When a document management system must convert uploaded EPS files into uniform-sized JPEG thumbnails for gallery views, the snippet resizes and saves them automatically.
 * 4. When a desktop application needs to show a quick preview of EPS artwork in a file‑open dialog, the code produces a consistent 150‑pixel square thumbnail.
 * 5. When a batch‑processing script has to prepare low‑resolution JPEG thumbnails from many EPS files for email attachments, this example demonstrates the resizing and saving steps.
 */
