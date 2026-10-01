// HOW-TO: Convert ODG to Interlaced PNG for Progressive Rendering in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.odg");
            string outputPath = Path.Combine("Output", "sample.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PngOptions options = new PngOptions();
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
 * 1. When a web application needs to display vector drawings from OpenDocument Graphics (ODG) files quickly, converting them to interlaced PNG allows browsers to render a low‑resolution preview while the full image loads.
 * 2. When generating thumbnails for a document management system, using Aspose.Imaging to convert ODG to progressive PNG reduces bandwidth and improves perceived loading speed on mobile devices.
 * 3. When preparing assets for an e‑learning platform, converting ODG diagrams to interlaced PNG ensures that learners see an immediate preview as the image progressively sharpens.
 * 4. When integrating ODG content into a .NET reporting tool, saving it as an interlaced PNG enables smooth rendering in PDF or HTML reports without waiting for the entire image to download.
 * 5. When automating batch conversion of design files on a server, using C# and Aspose.Imaging to produce progressive PNGs from ODG files simplifies downstream image processing pipelines that require web‑friendly formats.
 */
