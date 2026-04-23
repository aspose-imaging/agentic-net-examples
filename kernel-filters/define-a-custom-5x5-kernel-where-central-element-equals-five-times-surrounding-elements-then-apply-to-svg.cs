using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG and save as output PNG
            using (Image img = Image.Load(tempPath))
            {
                img.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}