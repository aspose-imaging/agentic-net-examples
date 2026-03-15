using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenAndSaveBigTiff
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dataDir = @"c:\temp\";

        // Load the source TIFF image
        using (Image image = Image.Load(dataDir + "sample.tif"))
        {
            // Cast to TiffImage to gain access to TIFF‑specific members
            TiffImage tiffImage = (TiffImage)image;

            // Apply a sharpen filter to the whole image.
            // Kernel size = 5, sigma = 4.0 (as shown in the documentation examples)
            tiffImage.Filter(
                tiffImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Create a BigTiffImage from the frames of the filtered TIFF image.
            // The constructor that accepts a TiffFrame[] is used as required by the rules.
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Save the result as a BigTIFF file.
            // The Save(string) overload is the prescribed lifecycle method.
            bigTiff.Save(dataDir + "sample_sharpened.bigtiff");
        }
    }
}