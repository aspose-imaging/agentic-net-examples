using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class DeconvolutionExample
{
    static void Main()
    {
        // Path to the folder containing the source GIF.
        string dir = @"c:\temp\";

        // Load the GIF image.
        using (Image image = Image.Load(dir + "sample.gif"))
        {
            // Cast to GifImage to access the Filter method.
            GifImage gifImage = (GifImage)image;

            // Apply a deconvolution filter (Gauss‑Wiener) to the whole image.
            // Radius = 5, Sigma = 4.0 – adjust these values as needed.
            gifImage.Filter(
                gifImage.Bounds,
                new GaussWienerFilterOptions(5, 4.0));

            // Save the processed image. PNG is used here for lossless output,
            // but you can save as GIF by omitting the options or using GifOptions.
            gifImage.Save(dir + "sample.Deconvolution.png", new PngOptions());
        }
    }
}