using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the folder containing the BigTIFF image
        string dataDir = @"C:\Temp\";

        // Load the BigTIFF image
        using (Image image = Image.Load(dataDir + "input.tif"))
        {
            // Cast to BigTiffImage to access TIFF-specific methods
            BigTiffImage bigTiff = (BigTiffImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            bigTiff.Filter(
                bigTiff.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image (overwrites or creates a new file)
            bigTiff.Save(dataDir + "output.tif");
        }
    }
}