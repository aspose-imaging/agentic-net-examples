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
            string inputPath = "input.svg";
            string outputPath = "output/output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                tiffOptions.VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };

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
 * 1. When a developer needs to convert an SVG illustration into a 300 dpi TIFF for high‑quality print while applying a shear transformation to correct skewed artwork, this C# code using Aspose.Imaging provides a quick solution.
 * 2. When an e‑commerce platform must generate catalog images from vector product drawings, applying a shear to align the view and saving as a high‑resolution TIFF ensures consistent printing standards.
 * 3. When a GIS application requires rasterizing map symbols stored as SVG, applying a shear to match map projection and exporting to TIFF at 300 dpi enables seamless integration with legacy raster layers.
 * 4. When a medical imaging system needs to archive vector‑based diagrams (e.g., SVG scans) with a shear correction for orientation and store them as lossless TIFF files for regulatory compliance, this snippet handles the process in .NET.
 * 5. When a publishing workflow automates the preparation of SVG logos for magazine layouts, applying a shear to adjust the logo’s angle and saving the result as a high‑resolution TIFF guarantees crisp, print‑ready assets.
 */