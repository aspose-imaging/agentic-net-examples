using System;
using System.IO;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input path
            string inputPath = "input.webp";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open a read-only file stream
            using (Stream stream = File.OpenRead(inputPath))
            // Load the WebP image from the stream
            using (WebPImage webPImage = new WebPImage(stream))
            {
                // Get the number of frames (pages) in the WebP image
                int frameCount = webPImage.PageCount;
                Console.WriteLine($"WebP frame count: {frameCount}");
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
 * 1. When building a C# web service that validates uploaded animated WebP files, a developer can use a file stream to load the image with Aspose.Imaging and log its frame count to ensure it meets the required animation length.
 * 2. When creating a desktop application that generates thumbnails for multi‑frame WebP assets, a developer needs to open the file via a stream, extract the PageCount, and decide how many preview images to produce.
 * 3. When implementing a batch processing script that archives only single‑frame WebP pictures, a developer can load each file from a stream, read the frame count, and skip files with more than one page.
 * 4. When developing a content‑management system that reports metadata for uploaded graphics, a developer can use Aspose.Imaging to load the WebP image from a stream and log its frame count as part of the image’s descriptive data.
 * 5. When troubleshooting animation glitches in an ASP.NET MVC app, a developer can read the WebP file through a stream, retrieve the number of frames, and compare it against expected values to diagnose rendering issues.
 */