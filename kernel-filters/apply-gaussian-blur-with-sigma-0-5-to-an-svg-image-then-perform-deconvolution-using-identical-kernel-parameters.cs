using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputPath = "input.svg";
        string outputDir = "output";
        string tempPngPath = Path.Combine(outputDir, "temp.png");
        string blurredPngPath = Path.Combine(outputDir, "blurred.png");
        string finalOutputPath = Path.Combine(outputDir, "result.png");

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(blurredPngPath));
        Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

        // Load SVG and rasterize to PNG (temporary file)
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Color.White
            };

            // PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(tempPngPath, pngOptions);
        }

        // Apply Gaussian blur (sigma 0.5, size 3) to the rasterized image
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(3, 0.5));
            raster.Save(blurredPngPath, new PngOptions());
        }

        // Perform deconvolution using identical kernel parameters
        using (Image img = Image.Load(blurredPngPath))
        {
            RasterImage raster = (RasterImage)img;
            raster.Filter(raster.Bounds, new GaussWienerFilterOptions(3, 0.5));
            raster.Save(finalOutputPath, new PngOptions());
        }
    }
}