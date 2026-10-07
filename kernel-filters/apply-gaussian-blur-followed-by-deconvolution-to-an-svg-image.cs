// HOW-TO: Apply Gaussian Blur and Deconvolution to SVG and Export as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.FileFormats.Svg.SvgImage svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Aspose.Imaging.Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);

                using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPngPath))
                {
                    var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                    raster.Filter(raster.Bounds, gaussianOptions);

                    int size = 3;
                    double sigma = 1.0;
                    var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(size, sigma);
                    var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.DeconvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, deconvOptions);

                    raster.Save(outputPath);
                }

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

/*
 * Real-World Use Cases:
 * 1. When you need to soften an SVG graphic with a Gaussian blur and then sharpen it using deconvolution before saving it as a PNG for web display.
 * 2. When you want to preprocess vector artwork by rasterizing it, applying a Gaussian blur for smoothing, and then deconvolving to enhance edges for high‑quality printing.
 * 3. When an application must convert SVG icons to high‑resolution PNG thumbnails while applying blur and deconvolution to improve visual consistency.
 * 4. When a batch job processes SVG diagrams, adds a controlled blur, and restores detail with deconvolution before storing the results in a PNG cache.
 * 5. When you are building a C# image‑processing pipeline that requires both blur and deblurring steps on vector images to prepare them for machine‑learning input.
 */
