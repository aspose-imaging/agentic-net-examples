// HOW-TO: Convert DICOM to Truecolor PNG in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.Truecolor
                };

                raster.Save(outputPath, options);
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
 * 1. When a medical imaging application needs to export DICOM scans as full‑color PNG files for web viewers.
 * 2. When a radiology workflow requires preserving the original color depth while converting DICOM images to a format supported by standard image editors.
 * 3. When integrating Aspose.Imaging into a C# service that generates PNG thumbnails of DICOM studies without losing truecolor information.
 * 4. When building a PACS archive that stores DICOM images as truecolor PNGs for easier sharing with clinicians using non‑DICOM viewers.
 * 5. When creating a batch conversion tool that transforms large sets of DICOM files to truecolor PNGs for machine‑learning preprocessing.
 */
