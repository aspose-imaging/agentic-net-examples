using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class SharpenDngExample
{
    static void Main()
    {
        // Path to the folder containing the DNG file
        string dataDir = @"c:\temp\";

        // Load the DNG image using the standard Image.Load method
        using (Image image = Image.Load(dataDir + "input.dng"))
        {
            // Cast the generic Image to DngImage to access DNG‑specific functionality
            DngImage dngImage = (DngImage)image;

            // Apply a sharpen filter to the whole image.
            // Kernel size = 5, sigma = 4.0 (same values used in Aspose examples)
            dngImage.Filter(
                dngImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image. Here we keep the original format (DNG).
            dngImage.Save(dataDir + "output.dng");
        }
    }
}