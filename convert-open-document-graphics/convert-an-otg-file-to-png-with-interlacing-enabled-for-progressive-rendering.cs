// HOW-TO: Convert OTG to PNG with Interlaced Progressive Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            using (PngOptions options = new PngOptions())
            {
                image.Save(outputPath, options);
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
 * 1. When a web application needs to display large OTG graphics quickly, a developer can convert them to interlaced PNG so browsers render the image progressively as it loads.
 * 2. When preparing assets for a mobile app that only supports PNG, converting OTG files with interlacing ensures a smaller initial download size and smoother user experience.
 * 3. When migrating legacy design files stored as OTG to a modern content management system, developers can batch‑convert them to PNG with progressive rendering for better compatibility.
 * 4. When generating thumbnails for an online gallery, converting OTG to interlaced PNG allows the thumbnails to appear faster on slow connections.
 * 5. When automating a build pipeline that packages images for e‑learning courses, converting OTG to interlaced PNG guarantees that the final PDFs render images incrementally during viewing.
 */
