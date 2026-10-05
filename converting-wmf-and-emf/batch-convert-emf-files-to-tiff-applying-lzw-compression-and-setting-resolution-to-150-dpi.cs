// HOW-TO: Batch Convert EMF to TIFF with LZW Compression and 150 DPI in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            string[] files = Directory.GetFiles(inputDirectory, "*.emf");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".tif");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb))
                    {
                        tiffOptions.ResolutionSettings = new ResolutionSetting(150, 150);
                        tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            SmoothingMode = SmoothingMode.None,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel
                        };

                        image.Save(outputPath, tiffOptions);
                    }
                }
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
 * 1. When you need to archive vector EMF drawings as smaller, lossless TIFF files for long‑term storage.
 * 2. When a printing workflow requires all images at a fixed 150 DPI resolution before sending to a RIP.
 * 3. When you must convert a large collection of EMF logos to TIFF with LZW compression to reduce disk usage.
 * 4. When generating TIFF assets for a document management system that only accepts raster formats.
 * 5. When automating the preparation of EMF diagrams for inclusion in PDF reports that need consistent DPI and compression.
 */
