// HOW-TO: Convert DjVu Pages 1 to 3 into Animated GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/animation.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DjVu document
            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Prepare GIF save options with page range 1‑3
                var gifOptions = new GifOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions(new IntRange(1, 3))
                };

                // Save selected pages as an animated GIF
                djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a subset of pages from a DjVu document and create a lightweight animated preview for web display.
 * 2. When you want to generate an animated GIF from selected DjVu pages to embed in an email newsletter.
 * 3. When you are building a document conversion service that turns multi‑page DjVu files into GIF animations for mobile devices.
 * 4. When you need to automate batch processing of DjVu files, converting specific page ranges into GIFs for archival or sharing.
 * 5. When you want to create a quick visual summary of a DjVu file by converting its first few pages into an animated GIF using C#.
 */
