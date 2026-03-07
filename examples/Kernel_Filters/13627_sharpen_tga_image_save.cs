using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the source TGA image
        string dataDir = @"c:\temp\";

        // Load the TGA image from file
        using (Image image = Image.Load(dataDir + "sample.tga"))
        {
            // Cast the generic Image to a TgaImage to access TGA‑specific members
            TgaImage tgaImage = (TgaImage)image;

            // Apply a sharpen filter to the whole image.
            // Kernel size = 5, sigma = 4.0 (as used in the documentation examples)
            tgaImage.Filter(tgaImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image back to disk (you can change the format if needed)
            tgaImage.Save(dataDir + "sample.SharpenFilter.tga");
        }
    }
}