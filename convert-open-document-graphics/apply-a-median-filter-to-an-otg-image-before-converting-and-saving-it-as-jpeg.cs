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
            // Hardcoded paths
            string inputPath = @"C:\temp\input.otg";
            string tempPngPath = @"C:\temp\temp.png";
            string outputPath = @"C:\temp\output.jpg";

            // Input file existence check
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories exist for temporary and final output
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Step 1: Load OTG image and rasterize to a temporary PNG
            using (Image otgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };
                pngOptions.VectorRasterizationOptions = otgRasterOptions;

                otgImage.Save(tempPngPath, pngOptions);
            }

            // Step 2: Load the rasterized PNG, apply median filter, and save as JPEG
            using (Image rasterImage = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImage;

                // Apply median filter with size 5 to the whole image
                raster.Filter(raster.Bounds, new MedianFilterOptions(5));

                var jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}