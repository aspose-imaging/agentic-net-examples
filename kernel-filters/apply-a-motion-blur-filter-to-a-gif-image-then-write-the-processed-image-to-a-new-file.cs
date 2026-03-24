using System;
using System.Drawing;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.gif";
        string outputPath = @"C:\Images\sample.MotionBlur.png";

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
            // Cast to GifImage to access the Filter method
            GifImage gifImage = (GifImage)image;

            // Apply a motion blur (motion wiener) filter to the whole image
            // Parameters: length = 10, sigma = 1.0, angle = 90.0 degrees
            gifImage.Filter(gifImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as PNG
            gifImage.Save(outputPath, new PngOptions());
        }
    }
}