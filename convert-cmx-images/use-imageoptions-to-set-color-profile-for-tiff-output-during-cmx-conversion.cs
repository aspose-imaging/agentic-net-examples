// HOW-TO: How to Set Color Profile for TIFF When Converting CMX in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "result.tiff");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a publishing workflow requires converting legacy CMX artwork to TIFF while preserving a specific ICC color profile for accurate print reproduction.
 * 2. When an automated batch process generates high‑resolution TIFF files from CMX designs and needs to embed sRGB or AdobeRGB profiles for downstream web or print services.
 * 3. When a digital asset management system imports CMX files and must store them as TIFFs with embedded color information to maintain color consistency across devices.
 * 4. When a graphics application offers users the option to export CMX drawings to TIFF and wants to ensure the exported file includes the chosen color profile for color‑critical workflows.
 * 5. When a quality‑control script validates that converted TIFF images from CMX contain the correct color profile before they are sent to a pre‑press department.
 */
