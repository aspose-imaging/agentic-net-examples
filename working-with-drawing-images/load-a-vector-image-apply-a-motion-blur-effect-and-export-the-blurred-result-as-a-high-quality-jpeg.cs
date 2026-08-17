// HOW-TO: Apply Motion Blur to SVG and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = vectorImage.Width,
                    PageHeight = vectorImage.Height,
                    BackgroundColor = Color.White
                };

                using (Image rasterImage = Image.Create(
                    new PngOptions { VectorRasterizationOptions = rasterOptions },
                    vectorImage.Width,
                    vectorImage.Height))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(15, 1.0, 45.0));

                    var jpegOptions = new JpegOptions { Quality = 100 };
                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a realistic motion‑blur effect to a vector logo (SVG) before delivering it as a high‑resolution JPEG for web or print.
 * 2. When an e‑commerce platform wants to generate stylized product thumbnails by blurring SVG icons and exporting them as compressed, quality‑preserved JPEGs.
 * 3. When a desktop application must convert user‑uploaded SVG diagrams into JPEG previews with a motion‑blur filter applied for visual emphasis.
 * 4. When a marketing automation script creates dynamic banner images by rasterizing SVG graphics, applying motion blur, and saving them as 100‑quality JPEG files.
 * 5. When a reporting tool requires fast processing of vector charts, adding motion blur for artistic effect, and outputting them as JPEGs compatible with legacy viewers.
 */
