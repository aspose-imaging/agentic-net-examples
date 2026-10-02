// HOW-TO: Sharpen EPS Image and Export as High‑Resolution JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output/high_res.jpg";
            string tempPngPath = "output/temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = 2000,
                PageHeight = 2000
            };

            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                epsImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });
            }

            using (var raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                var jpegOptions = new JpegOptions
                {
                    Quality = 100
                };

                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert a vector EPS logo to a crisp, high‑resolution JPEG for web or print, applying a sharpening filter to enhance detail.
 * 2. When preparing EPS‑based technical diagrams for inclusion in a PDF report, you can rasterize, sharpen, and save them as high‑quality JPEGs.
 * 3. When creating product images from EPS artwork for an e‑commerce site, sharpening the rasterized image ensures the final JPEG looks sharp on high‑DPI displays.
 * 4. When a legacy EPS file must be used in a mobile app, you can rasterize it at a large size, apply a sharpen filter, and export a high‑resolution JPEG compatible with the app.
 * 5. When batch‑processing EPS files for a marketing campaign, this code lets you automate sharpening and high‑resolution JPEG conversion to maintain visual consistency.
 */
