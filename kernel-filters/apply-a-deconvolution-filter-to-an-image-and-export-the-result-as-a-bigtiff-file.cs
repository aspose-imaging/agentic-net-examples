using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Path to the source image (must be a TIFF image)
        string inputPath = "input.tif";

        // Path where the resulting BigTIFF will be saved
        string outputPath = "output.tif";

        // Load the image using Aspose.Imaging lifecycle method
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TiffImage to gain access to the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Create deconvolution filter options (Gauss‑Wiener is a concrete implementation)
            var deconvOptions = new GaussWienerFilterOptions(radius: 5, sigma: 4.0);

            // Apply the filter to the whole image
            tiffImage.Filter(tiffImage.Bounds, deconvOptions);

            // Convert the filtered TIFF image to a BigTIFF image
            // Use the constructor that accepts an array of TiffFrame objects
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Save the result as a BigTIFF file
            bigTiff.Save(outputPath);
        }
    }
}