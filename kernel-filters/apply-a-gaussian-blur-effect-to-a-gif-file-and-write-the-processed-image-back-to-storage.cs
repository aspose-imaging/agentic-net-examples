using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample.GaussianBlur.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to use GIF‑specific functionality
            GifImage gifImage = (GifImage)image;

            // Apply Gaussian blur to the whole image (radius 5, sigma 4.0)
            gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to storage (preserves GIF format)
            gifImage.Save(outputPath);
        }
    }
}