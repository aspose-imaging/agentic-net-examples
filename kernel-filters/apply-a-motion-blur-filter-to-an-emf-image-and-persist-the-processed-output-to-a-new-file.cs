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
        string inputPath = @"C:\Images\input.emf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EMF image
        using (Image emfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options to convert EMF to raster format
            var rasterOptions = new EmfRasterizationOptions
            {
                PageSize = emfImage.Size
            };

            // Set up PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize EMF into a memory stream
            using (var ms = new MemoryStream())
            {
                emfImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream position for reading

                // Load the rasterized image
                using (Image rasterImage = Image.Load(ms))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply motion blur filter to the entire image
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image
                    raster.Save(outputPath);
                }
            }
        }
    }
}