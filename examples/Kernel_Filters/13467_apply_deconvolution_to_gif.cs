using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input GIF path (modify as needed)
        string inputPath = "input.gif";
        // Output image path (PNG format to view the result)
        string outputPath = "output.png";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gif = (GifImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            // Parameters: radius = 5, sigma = 4.0 (adjust as required)
            gif.Filter(gif.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered result as PNG
            gif.Save(outputPath, new PngOptions());
        }
    }
}