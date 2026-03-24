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
        string inputPath = @"c:\temp\sample.djvu";
        string outputPath = @"c:\temp\sample.MotionWienerFilter.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a motion Wiener (motion blur) filter to the whole image
            // Parameters: length = 10, sigma = 1.0, angle = 90.0 degrees
            djvuImage.Filter(djvuImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}