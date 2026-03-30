using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string inputDir = "Input\\Svg";
        string outputDir = "Output";

        string[] files = Directory.GetFiles(inputDir, "*.svg");
        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".png");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to PNG
            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Color.White
                };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                vectorImage.Save(outputPath, pngOptions);
            }

            // Apply Gaussian blur filter
            using (Image rasterImage = Image.Load(outputPath))
            {
                var raster = (RasterImage)rasterImage;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.0));
                raster.Save(outputPath);
            }
        }
    }
}