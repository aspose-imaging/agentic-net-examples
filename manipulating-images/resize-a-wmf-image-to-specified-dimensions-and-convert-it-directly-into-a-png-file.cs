using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Path to the source WMF file
        string inputPath = @"C:\Images\source.wmf";

        // Path where the resized PNG will be saved
        string outputPath = @"C:\Images\resized.png";

        // Desired output dimensions
        int targetWidth = 800;
        int targetHeight = 600;

        // Load the WMF image using the unified Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage to access vector‑specific functionality
            WmfImage wmfImage = (WmfImage)image;

            // Resize the image to the target dimensions.
            // BilinearResample provides a good quality trade‑off.
            wmfImage.Resize(targetWidth, targetHeight, ResizeType.BilinearResample);

            // Save the resized image directly as PNG.
            wmfImage.Save(outputPath, new PngOptions());
        }
    }
}