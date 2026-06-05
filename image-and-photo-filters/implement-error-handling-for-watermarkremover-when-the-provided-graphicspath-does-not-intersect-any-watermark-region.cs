using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
            Directory.CreateDirectory(outputDir);

        try
        {
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath(); // Empty mask, no intersection with watermark

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options);

                using (result)
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