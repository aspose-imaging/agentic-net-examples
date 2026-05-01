using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.otg";
            string tempBmpPath = @"C:\Images\temp.bmp";
            string outputPath = @"C:\Images\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image and rasterize it to a temporary BMP file
            using (Image otgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for OTG
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                // BMP save options with vector rasterization
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save rasterized image to temporary BMP
                otgImage.Save(tempBmpPath, bmpOptions);
            }

            // Load the temporary BMP as a raster image, apply median filter, and save final BMP
            using (Image bmpImage = Image.Load(tempBmpPath))
            {
                RasterImage rasterImage = (RasterImage)bmpImage;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}