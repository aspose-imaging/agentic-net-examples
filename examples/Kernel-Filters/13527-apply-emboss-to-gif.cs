using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Define input GIF path and output PNG path
        string inputPath = "input.gif";
        string outputPath = "output.png";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Apply an emboss filter using convolution filter options
            gif.Filter(
                gif.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Save the filtered image as PNG
            gif.Save(outputPath, new PngOptions());
        }
    }
}