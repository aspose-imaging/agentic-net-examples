using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.odg";
            string outputPath = @"C:\Images\sample_filtered.png";
            string tempPngPath = @"C:\Images\temp_raster.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load the ODG image
            using (Image odgImage = Image.Load(inputPath))
            {
                // Rasterize ODG to a temporary PNG file
                var rasterOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = odgImage.Size
                };
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                odgImage.Save(tempPngPath, pngSaveOptions);
            }

            // Load the rasterized PNG as a RasterImage
            using (Image image = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)image;

                // Apply median filter with size 5 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Save the filtered image as PNG
                rasterImage.Save(outputPath);
            }

            // Optionally delete the temporary raster PNG
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}