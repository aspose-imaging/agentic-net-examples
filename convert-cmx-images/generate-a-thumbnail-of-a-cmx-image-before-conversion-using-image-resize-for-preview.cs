// HOW-TO: Create PNG Thumbnail from CMX Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\Thumbnail\sample_thumbnail.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image
            using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
            {
                // Define thumbnail size (e.g., 150x150)
                int thumbWidth = 150;
                int thumbHeight = 150;

                // Resize the image to create a thumbnail preview
                cmxImage.Resize(thumbWidth, thumbHeight);

                // Save the thumbnail (PNG format)
                PngOptions pngOptions = new PngOptions();
                cmxImage.Save(outputPath, pngOptions);
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
 * 1. When you need to show a quick preview of a large CMX vector file in a web gallery without loading the full image.
 * 2. When generating thumbnail icons for a document management system that stores engineering drawings in CMX format.
 * 3. When creating low‑resolution PNG previews for email attachments that contain CMX drawings to reduce bandwidth.
 * 4. When building a desktop application that lists CMX files and requires uniform 150 × 150 pixel thumbnails for the UI.
 * 5. When automating batch processing of CMX assets to produce PNG thumbnails for a searchable image catalog.
 */
