// Path to the folder containing the source WebP image
string dir = @"c:\temp\";

// Load the WebP image using Aspose.Imaging.Image.Load and cast to WebPImage
using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(dir + "input.webp"))
{
    // Cast the generic Image to the specific WebPImage type
    Aspose.Imaging.FileFormats.Webp.WebPImage webpImage = (Aspose.Imaging.FileFormats.Webp.WebPImage)image;

    // Apply a Gaussian blur filter to the whole image.
    // Radius = 5, Sigma = 4.0 (adjust as needed for desired blur strength)
    webpImage.Filter(
        webpImage.Bounds,
        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image. Here we save as PNG, but you can also save as WebP by using WebPOptions.
    webpImage.Save(dir + "output_blur.png", new Aspose.Imaging.ImageOptions.PngOptions());
}