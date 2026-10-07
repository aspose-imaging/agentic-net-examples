// HOW-TO: Extract EPS Preview Image and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "preview.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions();
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
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
 * 1. When you need to generate a high‑resolution TIFF thumbnail from an EPS file for printing workflows.
 * 2. When a web service must convert embedded EPS preview data to a TIFF image for previewing in browsers that do not support EPS.
 * 3. When automating batch processing of design assets, extracting their EPS previews and storing them as TIFF files for archival or cataloging.
 * 4. When integrating with a document management system that requires TIFF format, you can extract the EPS preview and save it directly as TIFF using C#.
 * 5. When creating a PDF‑to‑TIFF conversion pipeline and you want to preserve the original EPS preview as a separate TIFF image for quality checks.
 */
