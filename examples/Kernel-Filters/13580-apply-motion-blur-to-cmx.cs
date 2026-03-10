using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input CMX, temporary raster image, and final output
        string inputCmxPath = "input.cmx";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Load the CMX vector image and rasterize it to PNG
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputCmxPath))
        {
            PngOptions pngOptions = new PngOptions();
            cmxImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply Motion Wiener (motion blur) filter, and save the result
        using (Image image = Image.Load(tempPngPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Apply motion blur with length=10, smooth=1.0, angle=90 degrees
            rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            PngOptions outputOptions = new PngOptions();
            rasterImage.Save(outputPath, outputOptions);
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}