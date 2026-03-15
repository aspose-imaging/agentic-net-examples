using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Expect input SVGZ path as first argument and output PNG path as second argument.
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <input.svgz> <output.png>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the compressed SVG (SVGZ) image.
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting vector to raster.
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Set up PNG save options with the rasterization options.
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the SVGZ to a PNG stored in memory.
            using (MemoryStream rasterStream = new MemoryStream())
            {
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized PNG as a RasterImage.
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply sharpen filter with kernel size 5 and sigma 4.0.
                    rasterImage.Filter(rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save the enhanced image to the specified output path.
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}