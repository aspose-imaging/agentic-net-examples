using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputSvgPath = @"C:\temp\input.svg";
            string originalPngPath = @"C:\temp\original.png";
            string blurredPngPath = @"C:\temp\blurred.png";

            // Verify input SVG exists
            if (!File.Exists(inputSvgPath))
            {
                Console.Error.WriteLine($"File not found: {inputSvgPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredPngPath));

            // Load SVG and rasterize to original PNG
            using (Image svgImage = Image.Load(inputSvgPath))
            {
                var vectorOptions = new SvgRasterizationOptions
                {
                    PageSize = ((SvgImage)svgImage).Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                svgImage.Save(originalPngPath, pngOptions);
            }

            // Load the rasterized PNG, apply Gaussian blur, and save blurred PNG
            using (Image img = Image.Load(originalPngPath))
            {
                RasterImage raster = (RasterImage)img;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                raster.Save(blurredPngPath);
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
 * 1. When a web designer wants to preview how a logo SVG will look after a Gaussian blur effect without distorting its vector edges, they can rasterize the SVG to PNG, apply the blur, and compare the results.
 * 2. When an e‑commerce platform generates product thumbnails from SVG icons and needs to ensure that applying a Gaussian blur for a soft‑focus background does not create visual artifacts, this code can automate the verification.
 * 3. When a mobile app developer creates SVG‑based UI assets and must test that the Gaussian blur filter applied at runtime preserves the original shape quality, they can use this script to rasterize, blur, and inspect the PNG output.
 * 4. When a printing service converts vector illustrations to raster images for blur‑based watermarking, they can run this code to confirm that the Gaussian blur radius and sigma values do not introduce unwanted pixelation in the final PNG.
 * 5. When a data‑visualization tool exports charts as SVG and later applies a Gaussian blur for emphasis, developers can employ this example to validate that the blur does not alter the chart’s line crispness before deployment.
 */