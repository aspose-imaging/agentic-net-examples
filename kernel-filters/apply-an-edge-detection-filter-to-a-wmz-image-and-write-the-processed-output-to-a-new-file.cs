using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WMZ file path (first argument or default)
        string inputPath = args.Length > 0 ? args[0] : "input.wmz";
        // Output raster image path (second argument or default)
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the WMZ (vector) image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Obtain rasterization options for the vector image
            VectorRasterizationOptions rasterOptions = (VectorRasterizationOptions)vectorImage.GetDefaultOptions(
                new object[] { Color.White, vectorImage.Width, vectorImage.Height });

            // Rasterize the vector image to a PNG stored in memory
            using (MemoryStream ms = new MemoryStream())
            {
                vectorImage.Save(ms, new PngOptions { VectorRasterizationOptions = rasterOptions });
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(ms))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply an edge detection (sharpen) filter to the entire image
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Save the processed image to the output file
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}