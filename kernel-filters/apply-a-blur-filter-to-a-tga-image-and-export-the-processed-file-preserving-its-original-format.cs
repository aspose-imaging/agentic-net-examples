using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the source TGA image
        string inputPath = @"C:\Images\sample.tga";

        // Path for the processed image (can be the same as input to overwrite)
        string outputPath = @"C:\Images\sample_blurred.tga";

        // Load the TGA image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to TgaImage to access TGA‑specific members
            TgaImage tgaImage = (TgaImage)image;

            // Apply a Gaussian blur filter to the whole image.
            // Radius = 5, Sigma = 4.0 – adjust these values as needed.
            tgaImage.Filter(
                tgaImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image, preserving the original TGA format.
            tgaImage.Save(outputPath);
        }
    }
}