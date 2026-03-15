using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output TIFF files
        string inputPath = "input.tif";
        string outputPath = "output_sharpened.tif";

        // Load the TIFF image
        using (Image image = Image.Load(inputPath))
        {
            TiffImage tiffImage = (TiffImage)image;

            // Apply a sharpen filter to the whole image
            tiffImage.Filter(
                tiffImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as a new TIFF file
            TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}