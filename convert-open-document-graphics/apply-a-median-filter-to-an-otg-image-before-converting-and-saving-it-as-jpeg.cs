using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.otg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with size 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Prepare JPEG save options with rasterization for vector content
            JpegOptions jpegOptions = new JpegOptions();
            OtgRasterizationOptions otgRasterization = new OtgRasterizationOptions
            {
                PageSize = image.Size
            };
            jpegOptions.VectorRasterizationOptions = otgRasterization;

            // Save the processed image as JPEG
            image.Save(outputPath, jpegOptions);
        }
    }
}