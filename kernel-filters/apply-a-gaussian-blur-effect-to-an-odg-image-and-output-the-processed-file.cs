using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.odg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Temporary rasterized PNG path
        string tempRasterPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_raster.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempRasterPath));

        // Load the ODG vector image and rasterize it to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for ODG
            OdgRasterizationOptions rasterOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = vectorImage.Size
            };

            // Configure PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Save rasterized image to temporary file
            vectorImage.Save(tempRasterPath, pngOptions);
        }

        // Load the rasterized PNG, apply Gaussian blur, and save the final result
        using (Image rasterImage = Image.Load(tempRasterPath))
        {
            RasterImage raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary raster file
        try
        {
            if (File.Exists(tempRasterPath))
                File.Delete(tempRasterPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}