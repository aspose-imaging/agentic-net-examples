// HOW-TO: Resize EPS to 2000px Width and Save as TIFF in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.eps";
        string outputPath = "output/output.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int newWidth = 2000;
                int newHeight = (int)Math.Round((double)epsImage.Height * newWidth / epsImage.Width);

                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = newWidth,
                    PageHeight = newHeight
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
 * 1. When you need to convert a vector EPS logo to a high‑resolution TIFF for printing while keeping the original aspect ratio.
 * 2. When a web service must generate a 2000‑pixel‑wide raster preview of an EPS file for thumbnail galleries.
 * 3. When a desktop application prepares EPS artwork for archival in TIFF format with a specific width constraint.
 * 4. When an automated batch process resizes multiple EPS diagrams to a uniform width before feeding them into a PDF composition workflow.
 * 5. When a GIS tool requires EPS map layers to be rasterized to TIFF at a set pixel width for further spatial analysis.
 */
