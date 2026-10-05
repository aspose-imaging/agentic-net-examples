// HOW-TO: Remove Motion Blur from PNG and Sharpen Edges Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 0.5));
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to restore a motion‑blurred PNG captured from a moving camera and improve its clarity in a C# application.
 * 2. When processing scanned documents that appear smeared due to camera shake, and you want to deblur and sharpen them before saving as PNG.
 * 3. When preparing product photos for an e‑commerce site, removing blur caused by handheld shooting and enhancing edge definition using Aspose.Imaging filters.
 * 4. When building an automated image‑processing pipeline that receives PNG files from drones, you can apply a Motion‑Wiener filter followed by sharpening to make details more visible.
 * 5. When creating a desktop tool for photographers to batch‑fix blurry PNG images, you can use the Motion‑Wiener and Sharpen filters in C# to improve image quality.
 */
