// HOW-TO: Convert SVG to PNG with Transparent Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector drawing (SVG) as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Prepare PNG export options with alpha channel
                PngOptions exportOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new StreamSource(new MemoryStream())
                };

                // Configure masking to make background transparent
                MaskingOptions maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.GraphCut,
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent,
                    ExportOptions = exportOptions
                };

                // Apply the mask (no explicit mask needed; background becomes transparent)
                ImageMasking.ApplyMask(image, null, maskingOptions);

                // Save the result as PNG with alpha channel
                image.Save(outputPath, exportOptions);
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
 * 1. When you need to embed an SVG logo into a web page that requires a PNG with an alpha channel for seamless overlay.
 * 2. When you must generate transparent PNG thumbnails from vector drawings for a mobile app UI.
 * 3. When you are converting user‑uploaded SVG icons to PNG format while preserving transparency for PDF reports.
 * 4. When you want to automate batch processing of SVG assets to create PNG assets with no background for game sprites.
 * 5. When you need to apply an opacity mask to remove the background of a vector illustration before saving it as a PNG for email newsletters.
 */
