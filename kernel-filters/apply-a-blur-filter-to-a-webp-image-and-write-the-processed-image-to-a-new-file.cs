using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing; // For Rectangle

class Program
{
    static void Main()
    {
        // Define source and destination file paths
        string sourcePath = @"c:\temp\input.webp";
        string destinationPath = @"c:\temp\output.png";

        // Load the WebP image using the provided load rule
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the loaded image to WebPImage to access WebP-specific methods
            WebPImage webpImage = (WebPImage)image;

            // Apply a Gaussian blur filter to the entire image using the provided Filter rule
            // Radius = 5, Sigma = 4.0 (adjust as needed for desired blur strength)
            webpImage.Filter(
                webpImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image to a new file using the provided save rule
            // Here we save as PNG, but you can use WebPOptions to save as WebP if required
            webpImage.Save(destinationPath, new PngOptions());
        }
    }
}