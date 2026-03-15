using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.svgz";
        string outputFile = "output.png";

        using (Image image = Image.Load(inputFile))
        {
            // Configure SVG rasterization options
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size,
                BackgroundColor = Color.White
            };

            // Set PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize the SVGZ to a memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, pngOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(ms))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply motion blur (motion wiener) filter
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image
                    raster.Save(outputFile);
                }
            }
        }
    }
}