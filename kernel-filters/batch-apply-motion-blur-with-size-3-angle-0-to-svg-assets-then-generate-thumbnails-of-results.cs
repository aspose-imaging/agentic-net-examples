using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // List of SVG assets to process
        string[] svgFiles = new[]
        {
            @"C:\Images\asset1.svg",
            @"C:\Images\asset2.svg"
        };

        foreach (string inputPath in svgFiles)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare paths for intermediate raster, filtered image, and thumbnail
            string baseName = Path.GetFileNameWithoutExtension(inputPath);
            string outputDir = Path.GetDirectoryName(inputPath);
            string rasterPath = Path.Combine(outputDir, baseName + "_raster.png");
            string filteredPath = Path.Combine(outputDir, baseName + "_filtered.png");
            string thumbPath = Path.Combine(outputDir, baseName + "_thumb.png");

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(rasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(filteredPath));
            Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(rasterPath, pngOptions);
            }

            // Load rasterized PNG, apply motion blur, save filtered image, and generate thumbnail
            using (Image img = Image.Load(rasterPath))
            {
                RasterImage raster = (RasterImage)img;

                // Apply motion blur with size 3, smooth 1.0, angle 0
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 0.0));

                // Save filtered image
                raster.Save(filteredPath);

                // Create thumbnail (100x100) using nearest neighbour resampling
                raster.Resize(100, 100, ResizeType.NearestNeighbourResample);
                raster.Save(thumbPath);
            }
        }
    }
}