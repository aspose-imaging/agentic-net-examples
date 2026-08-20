// HOW-TO: Convert CMX to TIFF with Custom ImageDescription Tag in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure TIFF options with a custom tag (ImageDescription)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.ImageDescription = "Custom tag value";
            tiffOptions.Source = new FileCreateSource(outputPath, false);

            // Load CMX image and save as TIFF using the configured options
            using (Image cmxImage = Image.Load(inputPath))
            {
                cmxImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as TIFF files for compatibility with document management systems.
 * 2. When you must embed a custom description into the TIFF metadata while converting from CMX for downstream processing.
 * 3. When an automated pipeline converts batch CMX assets to TIFF for printing workflows that require RGB photometric settings.
 * 4. When you want to ensure the output TIFF is created in a specific folder structure even if the source CMX file is missing.
 * 5. When you need to handle conversion errors gracefully in a C# application that processes user‑uploaded CMX files.
 */
