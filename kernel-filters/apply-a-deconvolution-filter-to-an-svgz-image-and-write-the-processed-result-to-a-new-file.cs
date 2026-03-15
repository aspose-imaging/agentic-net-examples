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
        // Input SVGZ file path
        string inputFile = Path.Combine("D:", "Compressed", "example.svgz");
        // Output raster image path (PNG format)
        string outputFile = Path.Combine("D:", "Compressed", "example_deconvolved.png");

        // Load the SVGZ image as a vector image
        using (Image vectorImage = Image.Load(inputFile))
        {
            // Rasterize the vector image to PNG in a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up rasterization options for SVG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size
                };

                // PNG save options with the rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save rasterized image to the memory stream
                vectorImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageBase = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageBase;

                    // Apply a deconvolution filter (Motion Wiener) to the entire image
                    rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(5, 1.0, 45.0));

                    // Save the processed raster image to the output file
                    rasterImage.Save(outputFile, new PngOptions());
                }
            }
        }
    }
}