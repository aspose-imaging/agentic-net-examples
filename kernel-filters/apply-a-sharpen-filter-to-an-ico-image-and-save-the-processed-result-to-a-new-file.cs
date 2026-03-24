using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Ico;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.ico";
        string outputPath = @"C:\Images\sample_sharpened.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to IcoImage to access raster operations
            IcoImage ico = (IcoImage)image;

            // Apply sharpen filter to the whole image
            ico.Filter(ico.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            ico.Save(outputPath);
        }
    }
}