// HOW-TO: Remove Watermark from BMP and Save as High Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\cleaned.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new RectangleShape(new RectangleF(0, 0, raster.Width, raster.Height)));
                mask.AddFigure(figure);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    var pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ResolutionSettings = new Aspose.Imaging.ResolutionSetting(300, 300)
                    };
                    result.Save(outputPath, pngOptions);
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
 * 1. When you need to clean a scanned BMP document that contains a faint watermark before archiving it as a printable PNG.
 * 2. When an application must automatically remove background logos from legacy BMP assets and output them at 300 DPI for high‑quality printing.
 * 3. When a batch process converts watermarked BMP screenshots into transparent‑free PNGs for use in marketing materials.
 * 4. When a digital‑forensics tool strips watermarks from BMP evidence files and stores the results in a lossless PNG format.
 * 5. When a web service receives BMP uploads with embedded watermarks and needs to return a cleaned, high‑resolution PNG for downstream image analysis.
 */
