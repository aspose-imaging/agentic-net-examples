using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = @"C:\temp\sample.tif";
        string outputPath = @"C:\temp\sample.EdgeDetection.png";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to a TiffImage to access TIFF‑specific methods
            TiffImage tiffImage = (TiffImage)image;

            // Apply a sharpen filter (commonly used for edge‑enhancement) to the whole image.
            // The SharpenFilterOptions constructor takes kernel size and sigma.
            tiffImage.Filter(tiffImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image to a new file (PNG format in this example)
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}