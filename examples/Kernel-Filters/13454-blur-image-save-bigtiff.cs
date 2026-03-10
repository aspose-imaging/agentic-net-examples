using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input TIFF image path
        string inputPath = @"C:\Temp\sample.tif";

        // Output path for the resulting BigTIFF image
        string outputPath = @"C:\Temp\sample_blurred.tif";

        // Load the image using the standard load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to access TIFF‑specific functionality
            TiffImage tiffImage = (TiffImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            tiffImage.Filter(
                tiffImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Create a BigTiffImage from the filtered frames
            // The constructor accepting an array of TiffFrame copies all frames
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Save the result using the standard save rule; the file will be a BigTIFF
            bigTiff.Save(outputPath);
        }
    }
}