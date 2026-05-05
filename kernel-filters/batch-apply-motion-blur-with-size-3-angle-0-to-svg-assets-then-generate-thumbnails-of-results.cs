using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "Input";
            string outputDir = "Output";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (var svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(svgPath);
                string blurredPath = Path.Combine(outputDir, fileName + "_blur.png");
                string thumbPath = Path.Combine(outputDir, fileName + "_thumb.png");
                string tempPngPath = Path.Combine(outputDir, fileName + "_temp.png");

                // Rasterize SVG to PNG (temporary file)
                using (Image svgImage = Image.Load(svgPath))
                {
                    var rasterOptions = new SvgRasterizationOptions();
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Load rasterized PNG, apply motion blur, and save blurred image
                using (Image rasterImg = Image.Load(tempPngPath))
                {
                    var raster = (RasterImage)rasterImg;
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 0.0));

                    Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));
                    raster.Save(blurredPath, new PngOptions());
                }

                // Create thumbnail from blurred image
                using (Image thumbImg = Image.Load(blurredPath))
                {
                    var thumbRaster = (RasterImage)thumbImg;
                    thumbRaster.Resize(200, 200, ResizeType.NearestNeighbourResample);

                    Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));
                    thumbRaster.Save(thumbPath, new PngOptions());
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}