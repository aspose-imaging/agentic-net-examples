using System;
using System.IO;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.gif";
        string outputPath = @"C:\Images\output_embossed.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the GIF image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific members
            GifImage gifImage = (GifImage)image;

            // Apply emboss filter using a predefined convolution kernel
            gifImage.Filter(gifImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as GIF
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}