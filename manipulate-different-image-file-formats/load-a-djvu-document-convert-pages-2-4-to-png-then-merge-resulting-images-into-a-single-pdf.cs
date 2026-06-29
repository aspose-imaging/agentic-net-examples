using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.djvu";
        string outputPath = "Output\\output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                Source src = new FileCreateSource(outputPath, false);
                PngOptions options = new PngOptions { Source = src };
                djvu.Save(outputPath, options);
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
 * 1. When a developer needs to extract pages 2‑4 from a multi‑page DjVu file and generate high‑quality PNG images for web preview using Aspose.Imaging for .NET.
 * 2. When an application must convert selected DjVu pages into PNG format and then combine those images into a single searchable PDF for archival or sharing.
 * 3. When a document‑management system requires automated processing of DjVu scans, converting specific pages to PNG thumbnails before bundling them into a PDF report.
 * 4. When a C# service processes user‑uploaded DjVu files, extracts a range of pages, saves them as PNG files, and merges them into a PDF to meet client‑specified output formats.
 * 5. When a workflow automates the transformation of DjVu e‑books by converting chosen pages to PNG and assembling them into a PDF booklet for printing or distribution.
 */