// HOW-TO: Convert EPS to High Resolution sRGB TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    ResolutionSettings = new ResolutionSetting(300, 300)
                };

                epsImage.Save(outputPath, tiffOptions);
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
 * 1. When a printing workflow requires converting vector EPS artwork to a 300 dpi sRGB TIFF for accurate color reproduction in downstream raster pipelines.
 * 2. When a web service must generate high‑resolution preview images from uploaded EPS files while ensuring the output uses the standard sRGB color space.
 * 3. When a desktop application needs to batch‑process design files, turning EPS logos into TIFFs suitable for inclusion in PDF reports that expect raster images.
 * 4. When an e‑commerce platform wants to display product illustrations by converting supplier‑provided EPS files to TIFFs with consistent color and resolution for thumbnails and print catalogs.
 * 5. When a digital asset management system must ingest EPS assets and store them as TIFFs with a fixed DPI and sRGB profile to maintain compatibility with legacy imaging tools.
 */
