// HOW-TO: Convert OTG to BMP with 150 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.otg");
            string outputPath = Path.Combine("Output", "sample.bmp");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new BmpOptions();
                options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(150, 150);
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
 * 1. When you need to prepare an OTG vector graphic for a Windows application that only accepts BMP files at a specific print quality.
 * 2. When generating high‑resolution thumbnails for a document management system that requires BMP output at 150 DPI.
 * 3. When converting legacy OTG drawings to BMP for inclusion in a PDF report where a fixed DPI ensures consistent scaling.
 * 4. When automating a batch process that extracts OTG assets and saves them as BMP images with a custom 150 DPI setting for accurate on‑screen rendering.
 * 5. When integrating Aspose.Imaging into a C# service that receives OTG uploads and must store them as BMP files with a defined resolution for downstream printing workflows.
 */
