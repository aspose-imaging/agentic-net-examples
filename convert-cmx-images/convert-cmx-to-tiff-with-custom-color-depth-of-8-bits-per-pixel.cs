// HOW-TO: Convert CMX to 8‑Bit TIFF Image in C# With Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.cmx";
        string outputPath = "Output\\result.tiff";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (CmxImage cmx = (CmxImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8 };
                tiffOptions.Photometric = TiffPhotometrics.MinIsBlack;
                tiffOptions.Compression = TiffCompressions.None;
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Create(tiffOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(tiff);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(cmx, 0, 0, width, height);
                    tiff.Save();
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as lossless 8‑bit TIFF files for long‑term storage.
 * 2. When a printing workflow requires CMX artwork to be converted to a TIFF format with a specific 8‑bit per pixel depth and no compression.
 * 3. When integrating Aspose.Imaging into a C# application to batch‑process CMX files and generate TIFFs that preserve exact grayscale values.
 * 4. When a document management system must display CMX content as TIFF thumbnails while maintaining a consistent photometric setting.
 * 5. When migrating legacy design assets to a TIFF‑based image repository and you need programmatic control over color depth and background color in C#.
 */
