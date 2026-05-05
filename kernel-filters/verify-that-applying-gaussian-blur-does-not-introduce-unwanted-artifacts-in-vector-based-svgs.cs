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
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string originalOutputPath = "original.png";
            string blurredOutputPath = "blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredOutputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG to PNG conversion
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

                // Save the original rasterized PNG
                using (FileStream originalStream = new FileStream(originalOutputPath, FileMode.Create, FileAccess.Write))
                {
                    svgImage.Save(originalStream, pngOptions);
                }
            }

            // Load the rasterized PNG as a RasterImage
            using (Image loadedImage = Image.Load(originalOutputPath))
            {
                RasterImage rasterImage = (RasterImage)loadedImage;

                // Apply Gaussian blur filter (radius 5, sigma 4.0)
                rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image
                using (FileStream blurredStream = new FileStream(blurredOutputPath, FileMode.Create, FileAccess.Write))
                {
                    rasterImage.Save(blurredStream, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}