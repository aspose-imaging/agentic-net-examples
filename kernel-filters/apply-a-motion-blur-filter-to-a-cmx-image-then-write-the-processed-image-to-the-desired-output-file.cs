using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\Images\sample.cmx";
        string outputPath = @"C:\Images\sample.MotionBlur.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX image, cast to RasterImage and apply a motion‑blur‑like filter
        using (Image image = Image.Load(inputPath))
        {
            // CMX is a vector format; Aspose.Imaging can rasterize it when cast to RasterImage
            var rasterImage = (RasterImage)image;

            // Apply a motion‑wiener filter (used here to achieve a motion blur effect)
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}