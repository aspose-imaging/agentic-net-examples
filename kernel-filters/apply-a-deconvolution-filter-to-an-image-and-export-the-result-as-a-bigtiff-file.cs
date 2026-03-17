using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;

class Program
{
    static void Main()
    {
        // Path to the source TIFF image
        string inputPath = "input.tif";

        // Path where the resulting BIGTIFF image will be saved
        string outputPath = "output.bigtiff";

        // Load the source image using the standard load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast the loaded image to TiffImage to access the Filter method
            TiffImage tiffImage = (TiffImage)image;

            // Apply a deconvolution filter (Gauss-Wiener) to the entire image
            // Radius = 5, Sigma = 4.0 are typical parameters; adjust as needed
            tiffImage.Filter(tiffImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Create a BigTiffImage from the filtered TIFF frames
            BigTiffImage bigTiff = new BigTiffImage(tiffImage.Frames);

            // Save the result as a BIGTIFF file using the standard save rule
            bigTiff.Save(outputPath);
        }
    }
}