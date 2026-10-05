// HOW-TO: Apply Motion Blur to SVG and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImg = Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImg.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(5, 1.0, 0.0);
                        raster.Filter(raster.Bounds, filterOptions);

                        var jpegOptions = new JpegOptions { Quality = 100 };
                        raster.Save(outputPath, jpegOptions);
                    }
                }
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
 * 1. When you need to add a realistic motion‑blur effect to a logo stored as SVG before publishing it as a high‑resolution JPEG on a website.
 * 2. When converting vector illustrations to raster format for print, and you want to simulate movement by applying a motion filter using Aspose.Imaging in a C# application.
 * 3. When generating thumbnail previews of SVG graphics with a blurred background for a gallery, requiring the final images to be saved as quality‑controlled JPEG files.
 * 4. When automating a batch process that reads SVG assets, applies a motion‑blur transformation, and outputs JPEGs for use in marketing materials without manual editing.
 * 5. When integrating image processing into a .NET service that receives SVG uploads, adds a motion‑blur effect for visual effect, and returns a high‑quality JPEG to the client.
 */
