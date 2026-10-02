// HOW-TO: Batch Resize DNG Images to 1024x768 and Convert to TIFF in C# (Aspose.Imaging for .NET)
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
            string inputDir = "Input";
            string outputDir = "Output";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] dngFiles = Directory.GetFiles(inputDir, "*.dng");

            foreach (string inputPath in dngFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                using (var dng = (Aspose.Imaging.FileFormats.Dng.DngImage)Image.Load(inputPath))
                {
                    dng.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    dng.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to downsize a collection of RAW DNG files to a standard 1024×768 resolution for quick preview and store them as TIFFs for compatibility with editing software.
 * 2. When a digital asset management system must automatically convert incoming DNG uploads into smaller TIFF files to reduce storage costs while preserving lossless quality.
 * 3. When a web service processes bulk DNG images from a camera and creates web‑ready TIFF thumbnails at a fixed size for display in an online gallery.
 * 4. When an archival workflow requires batch resizing of high‑resolution DNG scans before archiving them as TIFF files to meet size constraints.
 * 5. When a C# application integrates Aspose.Imaging to transform a folder of DNG photographs into uniformly sized TIFFs for downstream batch printing or analysis.
 */
