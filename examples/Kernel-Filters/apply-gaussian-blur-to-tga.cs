using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"C:\temp\sample.tga";
        string outputPath = @"C:\temp\sample.GaussianBlur.tga";

        // Load the TGA image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TgaImage to access the Filter method
            TgaImage tgaImage = (TgaImage)image;

            // Apply Gaussian blur filter to the entire image
            // Parameters: kernel size = 5, sigma = 4.0
            tgaImage.Filter(tgaImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image back to disk
            tgaImage.Save(outputPath);
        }
    }
}