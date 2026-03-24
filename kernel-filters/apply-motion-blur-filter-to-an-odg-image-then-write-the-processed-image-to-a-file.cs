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
        string inputPath = @"C:\Images\sample.odg";
        string outputPath = @"C:\Images\processed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempRasterPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the ODG vector image
        using (Image odgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG
            var rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = odgImage.Size
            };

            // Define PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize and save to a temporary PNG file
            odgImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (Image rasterImage = Image.Load(tempRasterPath))
        {
            // Cast to RasterImage to access filtering methods
            var raster = (RasterImage)rasterImage;

            // Apply a motion Wiener filter (used here as a motion blur effect)
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            var motionFilter = new MotionWienerFilterOptions(10, 1.0, 90.0);
            raster.Filter(raster.Bounds, motionFilter);

            // Save the processed image to the final output path
            raster.Save(outputPath);
        }

        // Clean up temporary file
        try
        {
            if (File.Exists(tempRasterPath))
                File.Delete(tempRasterPath);
        }
        catch
        {
            // Ignored – cleanup failure should not interrupt the program
        }
    }
}