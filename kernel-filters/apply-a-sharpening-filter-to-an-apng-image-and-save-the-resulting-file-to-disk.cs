using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output\\output_sharpened.apng";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the APNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to ApngImage (full namespace to avoid extra using)
            var apngImage = (Aspose.Imaging.FileFormats.Apng.ApngImage)image;

            // Apply sharpening filter to each frame
            foreach (var page in apngImage.Pages)
            {
                var frame = (Aspose.Imaging.FileFormats.Apng.ApngFrame)page;
                var raster = (RasterImage)frame;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            }

            // Save the modified APNG
            apngImage.Save(outputPath, new ApngOptions());
        }
    }
}