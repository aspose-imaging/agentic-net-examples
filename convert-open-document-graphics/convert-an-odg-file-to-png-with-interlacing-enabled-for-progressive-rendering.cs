// HOW-TO: Convert ODG to PNG with Progressive Interlacing in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\sample.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the ODG image
            using (Image image = Image.Load(inputPath))
            {
                // Set PNG options with progressive (interlaced) encoding
                var pngOptions = new PngOptions
                {
                    Progressive = true
                };

                // Save the image as PNG with the specified options
                image.Save(outputPath, pngOptions);
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
 * 1. When you need to display OpenDocument graphics on a website and want the image to appear gradually as it loads, you can convert ODG files to interlaced PNGs using C#.
 * 2. When building a document management system that stores drawings as ODG, you may generate preview thumbnails that load progressively in browsers by converting them to progressive PNGs.
 * 3. When creating a reporting tool that embeds vector drawings into PDF or HTML, converting ODG to PNG with progressive encoding reduces perceived load time for end users.
 * 4. When migrating legacy OpenDocument graphics to a modern asset pipeline, automating the conversion to interlaced PNGs improves page rendering performance on low‑bandwidth connections.
 * 5. When developing a mobile app that downloads images over slow networks, converting ODG to a progressive PNG ensures the image becomes visible incrementally as data arrives.
 */
