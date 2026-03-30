using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

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
        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Aspose.Imaging.Image rasterImg = Aspose.Imaging.Image.Load(ms))
                {
                    Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)rasterImg;

                    // Apply Gaussian blur with size 5 and sigma 2.8
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 2.8));

                    // Save the filtered raster image
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}