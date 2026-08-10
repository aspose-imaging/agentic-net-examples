// HOW-TO: Apply Tilt‑Shift Effect To SVG And Save As High‑Resolution JPEG In C# (Aspose.Imaging for .NET)
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

                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };

                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        int width = raster.Width;
                        int height = raster.Height;
                        int blurHeight = height / 3;

                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(15, 5.0);

                        raster.Filter(new Rectangle(0, 0, width, blurHeight), blurOptions);
                        raster.Filter(new Rectangle(0, height - blurHeight, width, blurHeight), blurOptions);

                        var jpegOptions = new JpegOptions
                        {
                            Quality = 95,
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

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
 * 1. When you need to convert a vector logo (SVG) into a print‑ready JPEG with a tilt‑shift blur for a stylized brochure cover.
 * 2. When an e‑commerce site wants to generate high‑resolution product thumbnails from SVG artwork with a selective blur effect for visual emphasis.
 * 3. When a mobile app creates custom postcards by rasterizing user‑uploaded SVG designs, applying a tilt‑shift look, and exporting a 300 dpi JPEG for printing.
 * 4. When a marketing automation workflow automatically transforms SVG infographics into JPEG images with a top‑and‑bottom blur to simulate depth of field.
 * 5. When a desktop publishing tool programmatically adds a tilt‑shift effect to vector illustrations before saving them as high‑quality JPEGs for magazine layouts.
 */
