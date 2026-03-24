using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.gif";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific functionality
            GifImage gifImage = (GifImage)image;

            // Apply a deconvolution filter (Gauss-Wiener) to the whole image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            gifImage.Filter(gifImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image as PNG
            gifImage.Save(outputPath, new PngOptions());
        }
    }
}