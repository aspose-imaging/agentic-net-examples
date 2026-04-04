using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\vector.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempPngPath = Path.Combine(Path.GetTempPath(), "tempRaster.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Rasterize vector image to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load rasterized image and save as output PNG
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            rasterImage.Save(outputPath, new PngOptions());
        }

        // Clean up temporary file
        try
        {
            File.Delete(tempPngPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}