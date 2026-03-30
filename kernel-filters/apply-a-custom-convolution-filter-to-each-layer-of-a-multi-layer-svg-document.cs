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
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            SvgImage svgImage = image as SvgImage;
            if (svgImage == null)
            {
                Console.Error.WriteLine("Input file is not an SVG image.");
                return;
            }

            // Prepare rasterization options for PNG output
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Temporary PNG file to hold the rasterized SVG
            string tempPngPath = Path.Combine(Path.GetTempPath(), "temp_raster.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Rasterize SVG to PNG
            svgImage.Save(tempPngPath, pngOptions);

            // Load the rasterized image
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImg;

                // Define a custom convolution kernel (sharpen filter)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Apply the custom convolution filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the filtered image to the final output path
                rasterImage.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                try { File.Delete(tempPngPath); } catch { /* ignore */ }
            }
        }
    }
}