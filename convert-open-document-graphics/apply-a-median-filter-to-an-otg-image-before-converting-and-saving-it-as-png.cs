using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded paths
            string inputPath = @"C:\Images\sample.otg";
            string intermediatePath = @"C:\Images\temp.png";
            string outputPath = @"C:\Images\sample_filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG output
                var otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size
                };

                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save the OTG image as a temporary PNG (rasterized)
                otgImage.Save(intermediatePath, pngSaveOptions);
            }

            // Load the rasterized PNG, apply median filter, and save final PNG
            using (Image pngImage = Image.Load(intermediatePath))
            {
                var rasterImage = (RasterImage)pngImage;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}