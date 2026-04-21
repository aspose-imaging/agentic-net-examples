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
            // Hardcoded directories
            string inputDir = "InputSvg";
            string outputDir = "OutputSvg";
            string thumbDir = "Thumbnails";
            string tempDir = "Temp";

            // Ensure output directories exist
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(thumbDir);
            Directory.CreateDirectory(tempDir);

            // Process each SVG file in the input directory
            foreach (var inputPath in Directory.GetFiles(inputDir, "*.svg"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string tempPngPath = Path.Combine(tempDir, fileName + ".png");
                string blurredPath = Path.Combine(outputDir, fileName + "_blur.png");
                string thumbPath = Path.Combine(thumbDir, fileName + "_thumb.png");

                // Ensure directories for each output file
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));
                Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));

                // Rasterize SVG to PNG
                using (Image svgImage = Image.Load(inputPath))
                {
                    PngOptions pngOptions = new PngOptions();
                    pngOptions.VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Apply motion blur filter to the rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(3, 1.0, 0.0));
                    raster.Save(blurredPath);
                }

                // Generate thumbnail from the blurred image
                using (RasterImage thumb = (RasterImage)Image.Load(blurredPath))
                {
                    int thumbWidth = 150;
                    int thumbHeight = (int)(thumb.Height * (150.0 / thumb.Width));
                    thumb.Resize(thumbWidth, thumbHeight);
                    thumb.Save(thumbPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}