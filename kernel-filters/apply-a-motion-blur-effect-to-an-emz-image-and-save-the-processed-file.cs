using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input EMZ, temporary PNG, and output image
        string inputPath = "input.emz";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the EMZ (vector) image and rasterize it to PNG
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Obtain rasterization options for the vector image
            var vectorRasterizationOptions = (VectorRasterizationOptions)vectorImage.GetDefaultOptions(new object[] { Aspose.Imaging.Color.White, vectorImage.Width, vectorImage.Height });

            // Rasterize and save as PNG
            var pngOptions = new PngOptions { VectorRasterizationOptions = vectorRasterizationOptions };
            vectorImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG and apply a motion blur effect
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)img;

            // Apply motion blur using MotionWienerFilterOptions (length, smooth, angle)
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}