// HOW-TO: Apply Tilt‑Shift Blur to SVG and Save as High‑Resolution JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

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

            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, new PngOptions());
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        int width = raster.Width;
                        int height = raster.Height;

                        Aspose.Imaging.Rectangle topRect = new Aspose.Imaging.Rectangle(0, 0, width, height / 3);
                        Aspose.Imaging.Rectangle bottomRect = new Aspose.Imaging.Rectangle(0, 2 * height / 3, width, height / 3);

                        raster.Filter(topRect, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));
                        raster.Filter(bottomRect, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0));

                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 100,
                            Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to convert an SVG logo into a stylized JPEG with a tilt‑shift blur for marketing brochures.
 * 2. When you want to generate high‑resolution product images from vector artwork and add selective top and bottom blur to create a depth‑of‑field effect.
 * 3. When an e‑commerce platform requires thumbnail images that simulate a miniature scene by applying blur to the upper and lower thirds of an SVG illustration before saving as JPEG.
 * 4. When automating batch processing of vector diagrams to produce print‑ready JPEGs with artistic tilt‑shift styling using Aspose.Imaging in a C# workflow.
 * 5. When integrating image processing into a C# application to render SVG icons with a tilt‑shift effect and export them as high‑quality JPEG files for web delivery.
 */
