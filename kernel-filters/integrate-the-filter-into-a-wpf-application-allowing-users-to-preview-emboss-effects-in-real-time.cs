using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.png";
        string outputPath = @"C:\temp\sample_emboss.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply a sharpen filter (used here as an emboss-like effect), and save
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}