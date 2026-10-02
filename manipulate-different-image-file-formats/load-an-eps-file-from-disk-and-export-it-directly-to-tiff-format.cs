// HOW-TO: Convert EPS to TIFF with Custom Raster Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.eps";
        string outputPath = "output/output.tiff";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage image = (EpsImage)Image.Load(inputPath))
            {
                EpsRasterizationOptions rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = 1000,
                    PageHeight = 1000
                };

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    VectorRasterizationOptions = rasterOptions
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
 * 1. When you need to generate a high‑resolution TIFF preview of an EPS vector logo for printing pipelines.
 * 2. When a document conversion service must transform uploaded EPS artwork into TIFF for compatibility with legacy imaging systems.
 * 3. When an automated batch job creates TIFF thumbnails of EPS files to display in a web gallery.
 * 4. When a GIS application requires rasterized EPS maps saved as TIFF to overlay with raster data.
 * 5. When a digital archiving workflow stores vector EPS drawings as lossless TIFF files for long‑term preservation.
 */
