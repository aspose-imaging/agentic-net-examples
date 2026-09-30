// HOW-TO: Convert JPEG to PSD with 300 DPI Resolution in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var options = new PsdOptions();
                options.ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300.0, 300.0);
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
 * 1. When a developer needs to generate print‑ready PSD files from JPEG images with a specific 300 DPI resolution for high‑quality printing.
 * 2. When an e‑commerce platform must export product photos as layered PSDs while ensuring the output meets the printer’s DPI requirements.
 * 3. When a desktop publishing workflow requires converting source images to PSD format and setting the resolution to match magazine layout specifications.
 * 4. When an automated batch process creates PSD assets from user‑uploaded photos and must enforce a consistent 300 DPI setting for downstream design tools.
 * 5. When a graphic‑design integration needs to preserve image dimensions and embed a 300 DPI resolution flag during JPEG‑to‑PSD conversion in a C# application.
 */
