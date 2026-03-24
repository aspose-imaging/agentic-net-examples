using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.odg";
        string outputPath = @"C:\temp\sample_sharpened.odg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the ODG image
        using (Image image = Image.Load(inputPath))
        {
            // Attempt to treat the loaded image as a raster image
            RasterImage raster = image as RasterImage;

            if (raster != null)
            {
                // Apply sharpen filter directly to the raster image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                raster.Save(outputPath);
            }
            else
            {
                // ODG is a vector format; rasterize it first, then apply the filter
                var rasterizationOptions = new OdgRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageSize = image.Size
                };

                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                // Temporary raster file path
                string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

                // Save vector image as raster PNG
                image.Save(tempRasterPath, pngSaveOptions);

                // Load the temporary raster image, apply filter, and save final result
                using (RasterImage tempRaster = (RasterImage)Image.Load(tempRasterPath))
                {
                    tempRaster.Filter(tempRaster.Bounds, new SharpenFilterOptions(5, 4.0));
                    tempRaster.Save(outputPath);
                }

                // Clean up temporary file
                File.Delete(tempRasterPath);
            }
        }
    }
}