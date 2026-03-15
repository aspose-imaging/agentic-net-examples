using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

string inputPath = @"c:\temp\sample.gif";
string outputPath = @"c:\temp\sample_sharpened.gif";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to GifImage to access GIF‑specific functionality
    GifImage gifImage = (GifImage)image;

    // Apply a sharpen filter to the whole image.
    // Parameters: kernel size = 5, sigma = 4.0 (same as the documentation example)
    gifImage.Filter(gifImage.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the processed image back to GIF format.
    gifImage.Save(outputPath, new GifOptions());
}