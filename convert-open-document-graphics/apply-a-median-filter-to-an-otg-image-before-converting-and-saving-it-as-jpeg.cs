using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

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
        using (Image otgImage = Image.Load(inputPath))
        {
            // Rasterize the OTG image to a raster format (PNG) using a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options for OTG
                OtgRasterizationOptions rasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // Save the rasterized image to the memory stream as PNG
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                otgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image as a RasterImage
                using (Image rasterImageBase = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access filtering functionality
                    RasterImage rasterImage = (RasterImage)rasterImageBase;

                    // Apply a median filter with size 5 to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                    // Save the filtered image as JPEG
                    JpegOptions jpegOptions = new JpegOptions();
                    rasterImage.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}