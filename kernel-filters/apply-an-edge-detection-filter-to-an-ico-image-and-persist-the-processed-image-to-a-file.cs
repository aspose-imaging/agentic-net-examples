using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.ico";
        string outputPath = @"C:\Images\output.ico";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ICO image, apply a sharpen (edge detection) filter, and save
        using (Aspose.Imaging.FileFormats.Ico.IcoImage image = (Aspose.Imaging.FileFormats.Ico.IcoImage)Image.Load(inputPath))
        {
            // Apply sharpen filter to the whole image
            image.Filter(image.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image
            image.Save(outputPath);
        }
    }
}