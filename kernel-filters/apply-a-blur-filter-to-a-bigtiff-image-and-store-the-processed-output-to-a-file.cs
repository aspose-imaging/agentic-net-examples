using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.ImageFilters.FilterOptions;

string inputPath = @"C:\Images\input.bigtiff";
string outputPath = @"C:\Images\output.bigtiff";

using (Image image = Image.Load(inputPath))
{
    // Cast the loaded image to BigTiffImage to access TIFF-specific functionality
    BigTiffImage bigTiff = (BigTiffImage)image;

    // Apply a Gaussian blur filter to the entire image
    // Radius = 5, Sigma = 4.0 (adjust as needed)
    bigTiff.Filter(bigTiff.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the processed image to a new file
    bigTiff.Save(outputPath);
}