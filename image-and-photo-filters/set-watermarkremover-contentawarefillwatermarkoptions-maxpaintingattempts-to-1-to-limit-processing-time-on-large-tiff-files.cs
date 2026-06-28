using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Watermark;
using Aspose.Imaging.Watermark.Options;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Images\large.tif";
        string outputPath = @"C:\Images\output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var bigTiff = (BigTiffImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(100, 100, 200, 200)));
                mask.AddFigure(figure);

                var options = new ContentAwareFillWatermarkOptions(mask)
                {
                    MaxPaintingAttempts = 1
                };

                using (var result = WatermarkRemover.PaintOver(bigTiff, options))
                {
                    result.Save(outputPath);
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
 * 1. When processing multi‑gigabyte BigTIFF satellite images on a web server, a developer can set MaxPaintingAttempts to 1 to keep the watermark removal step fast enough to meet request‑timeout limits.
 * 2. In an automated nightly batch that strips watermarks from thousands of scanned legal documents stored as TIFF files, limiting painting attempts prevents the job from stalling on unusually large pages.
 * 3. When integrating Aspose.Imaging into a serverless Azure Function that must return a PNG preview within a few seconds, using MaxPaintingAttempts = 1 ensures the content‑aware fill completes quickly even for high‑resolution TIFFs.
 * 4. For a desktop application that lets users preview cleaned‑up medical DICOM images saved as TIFF, setting the max attempts to one avoids long UI freezes while still providing a reasonable removal result.
 * 5. During a continuous‑integration pipeline that validates image assets, developers can cap the painting attempts to one to guarantee that the watermark‑removal step does not exceed the allotted build time for very large TIFF files.
 */