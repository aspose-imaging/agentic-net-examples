// HOW-TO: Convert CorelDRAW CDR to 16‑Bit PSD in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                CdrImage cdr = (CdrImage)image;
                using (PsdOptions options = new PsdOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
                    cdr.Save(outputPath, options);
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
 * 1. When you need to batch‑convert CorelDRAW CDR files to Photoshop PSD files with 16‑bit color depth in a C# .NET service.
 * 2. When integrating an automated workflow that extracts vector artwork from CDR and saves it as high‑color‑depth PSD for further editing in Photoshop.
 * 3. When building a desktop application that allows users to open legacy CDR designs and export them as 16‑bit PSD images for print‑ready production.
 * 4. When migrating a design library from CorelDRAW to Photoshop and must retain the full 16‑bit per channel color information using Aspose.Imaging.
 * 5. When creating a server‑side API that receives CDR uploads and returns PSD files with 16‑bit depth for downstream image‑processing pipelines.
 */
