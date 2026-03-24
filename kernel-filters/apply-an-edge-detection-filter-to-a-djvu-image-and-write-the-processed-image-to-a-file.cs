using System;
using System.IO;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.djvu";
        string outputPath = @"C:\Images\sample.EdgeDetected.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a sharpen filter (acts as edge detection) to the entire image
            djvuImage.Filter(djvuImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}