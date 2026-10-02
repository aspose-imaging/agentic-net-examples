// HOW-TO: Convert EPS to High Resolution sRGB TIFF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int highResWidth = epsImage.Width * 2;
                int highResHeight = epsImage.Height * 2;

                var rasterOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = highResWidth,
                    PageHeight = highResHeight
                };

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Compression = TiffCompressions.Lzw,
                    ResolutionUnit = TiffResolutionUnits.Inch,
                    Xresolution = new TiffRational(300),
                    Yresolution = new TiffRational(300),
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
 * 1. When you need to turn a vector EPS artwork into a printable 300 dpi TIFF for a publishing workflow using C#.
 * 2. When a graphics pipeline requires converting EPS files to sRGB color space TIFFs with loss‑less LZW compression for archival storage.
 * 3. When an automated batch process must rasterize EPS logos at double the original size to preserve detail in high‑resolution scans.
 * 4. When a .NET application has to generate white‑background TIFFs from EPS files for inclusion in PDF reports or catalogs.
 * 5. When you want to programmatically ensure EPS images are saved as TIFFs with proper resolution units and DPI settings for print‑ready output.
 */
