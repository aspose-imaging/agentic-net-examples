using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.djvu";
        string outputPath = @"C:\temp\sample.Blur.png";

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
            // Cast to DjvuImage to access DJVU-specific functionality
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a Gaussian blur filter to the whole image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            djvuImage.Filter(djvuImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}