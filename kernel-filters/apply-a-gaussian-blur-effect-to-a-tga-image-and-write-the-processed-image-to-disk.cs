using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = @"C:\Images\sample.tga";
        string outputPath = @"C:\Images\sample.GaussianBlur.tga";

        // Load the TGA image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to TgaImage to access TGA‑specific members
            TgaImage tgaImage = (TgaImage)image;

            // Apply Gaussian blur to the whole image.
            // Parameters: kernel size = 5, sigma = 4.0 (adjust as needed)
            tgaImage.Filter(tgaImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to disk (keeps TGA format)
            tgaImage.Save(outputPath);
        }
    }
}