// HOW-TO: Recover Corrupted TIFF Using ConsistentRecover Mode In C# (Aspose.Imaging for .NET)
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
            string inputPath = "corrupted.tif";
            string outputPath = "output\\recovered.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            LoadOptions loadOptions = new LoadOptions
            {
                DataRecoveryMode = DataRecoveryMode.ConsistentRecover,
                DataBackgroundColor = Color.White
            };

            using (Image image = Image.Load(inputPath, loadOptions))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a batch of scanned TIFF documents is corrupted and you need to automatically recover them with Aspose.Imaging before archiving.
 * 2. When an image‑processing service receives user‑uploaded TIFF files that may be partially damaged and must load them for further manipulation.
 * 3. When a legacy application writes TIFF files with occasional write errors and you need to programmatically restore the images for analysis.
 * 4. When you need to clean up corrupted medical imaging TIFFs (e.g., converted DICOM) so they can be processed by diagnostic algorithms.
 * 5. When a digital asset management system must import corrupted TIFF assets, recover them, and save a repaired version for downstream editing.
 */
