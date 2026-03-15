using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

// Define input and output paths
string dataDir = @"c:\temp\";
string inputPath = Path.Combine(dataDir, "sample.jp2");
string outputPath = Path.Combine(dataDir, "sample.SharpenFilter.jp2");

// Load the JPEG2000 image
using (Image image = Image.Load(inputPath))
{
    // Cast to RasterImage to access filtering functionality
    RasterImage rasterImage = (RasterImage)image;

    // Apply a sharpen filter (kernel size = 5, sigma = 4.0) to the whole image
    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

    // Save the processed image back as JPEG2000
    rasterImage.Save(outputPath);
}