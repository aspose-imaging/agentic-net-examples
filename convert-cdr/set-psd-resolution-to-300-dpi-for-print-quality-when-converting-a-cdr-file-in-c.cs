// HOW-TO: Convert CDR to PSD With 300 DPI Resolution In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "sample.psd");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PsdOptions options = new PsdOptions())
                {
                    options.ResolutionSettings = new ResolutionSetting(300, 300);
                    image.Save(outputPath, options);
                }
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
 * 1. When you need to prepare a CorelDRAW (CDR) illustration for high‑quality printing by converting it to a Photoshop PSD file with a 300 DPI resolution using C#.
 * 2. When an automated workflow must generate print‑ready PSD assets from CDR source files without manual resizing, ensuring the correct DPI for press standards.
 * 3. When integrating Aspose.Imaging into a .NET application to batch‑process CDR designs and output them as PSDs calibrated for 300 DPI to match corporate branding guidelines.
 * 4. When a designer wants to preserve vector details from a CDR file while delivering a raster PSD at print‑grade resolution for further editing in Photoshop.
 * 5. When a server‑side service converts user‑uploaded CDR files to PSD format and must set the resolution to 300 DPI to meet publishing requirements.
 */
