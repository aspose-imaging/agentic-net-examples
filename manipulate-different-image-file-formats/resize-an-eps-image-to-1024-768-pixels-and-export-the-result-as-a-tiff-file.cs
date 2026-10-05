// HOW-TO: Resize EPS to 1024x768 and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.eps";
        string outputPath = "output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image epsImage = Image.Load(inputPath))
            {
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = 1024,
                    PageHeight = 768
                };

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
 * 1. When you need to convert a vector EPS logo into a high‑resolution TIFF for print‑ready PDFs.
 * 2. When a web service must generate 1024×768 preview thumbnails from EPS files and store them as lossless TIFFs.
 * 3. When an archival system requires rasterizing EPS drawings to a fixed size TIFF to ensure consistent viewing across platforms.
 * 4. When a desktop application needs to batch‑process EPS artwork, resizing each to 1024×768 before saving as TIFF for downstream GIS tools.
 * 5. When integrating Aspose.Imaging in a C# workflow to transform EPS schematics into TIFF images that match a specific page dimension for reporting.
 */
