using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.svg";
        string outputPath = @"C:\temp\output.png";

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
            // Rasterize SVG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                using (PngOptions pngOptions = new PngOptions())
                {
                    svgImage.Save(rasterStream, pngOptions);
                }

                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(rasterStream))
                {
                    Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                    // Apply Gaussian blur filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Apply Gauss-Wiener deconvolution filter
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0));

                    // Save the processed image to the output path
                    using (PngOptions outOptions = new PngOptions())
                    {
                        rasterImage.Save(outputPath, outOptions);
                    }
                }
            }
        }
    }
}