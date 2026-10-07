// HOW-TO: Limit Watermark Removal Time on Large TIFF Files in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.tif";
        string outputPath = "output/processed.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, 100, 100)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask);
                options.MaxPaintingAttempts = 1;

                var result = WatermarkRemover.PaintOver((RasterImage)image, options);
                using (result)
                {
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    result.Save(outputPath, tiffOptions);
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
 * 1. When processing multi‑gigabyte scanned TIFF documents that contain watermarks, you can limit the removal algorithm to a single painting attempt to keep the operation fast.
 * 2. When integrating Aspose.Imaging into a document‑archiving pipeline, setting MaxPaintingAttempts to 1 prevents long pauses while cleaning watermarks from large TIFF images.
 * 3. When building a web service that accepts high‑resolution TIFF uploads, you can use this code to quickly strip watermarks without exhausting server resources.
 * 4. When performing batch conversion of TIFF files with embedded watermarks, limiting painting attempts ensures consistent processing time across all files.
 * 5. When developing a desktop utility for users to clean confidential TIFF scans, the single‑attempt setting helps maintain a responsive UI even on very large images.
 */
