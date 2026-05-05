using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPath, pngOptions);
            }

            using (Image rasterImage = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)rasterImage;

                double[,] blurKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(3);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurKernel);

                raster.Filter(raster.Bounds, blurOptions);

                var finalPngOptions = new PngOptions();
                raster.Save(outputPath, finalPngOptions);
            }

            try
            {
                File.Delete(tempPath);
            }
            catch
            {
                // Ignore cleanup errors
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}