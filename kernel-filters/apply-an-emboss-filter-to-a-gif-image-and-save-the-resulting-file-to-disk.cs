using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF file path
        string inputPath = "input.gif";
        // Output GIF file path
        string outputPath = "output_emboss.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Apply an emboss filter using a predefined convolution kernel
            gif.Filter(gif.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as a GIF
            gif.Save(outputPath, new GifOptions());
        }
    }
}