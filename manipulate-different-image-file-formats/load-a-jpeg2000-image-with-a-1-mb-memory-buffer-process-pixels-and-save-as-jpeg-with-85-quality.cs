// HOW-TO: Convert JPEG2000 to JPEG with Color Inversion and 85% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jp2";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            var loadOptions = new LoadOptions { BufferSizeHint = 1 * 1024 * 1024 };
            using (Jpeg2000Image jp2Image = (Jpeg2000Image)Image.Load(inputPath, loadOptions))
            {
                using (RasterImage raster = (RasterImage)jp2Image)
                {
                    if (!raster.IsCached)
                        raster.CacheData();

                    var rect = new Rectangle(0, 0, raster.Width, raster.Height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);

                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int a = (pixels[i] >> 24) & 0xFF;
                        int r = (pixels[i] >> 16) & 0xFF;
                        int g = (pixels[i] >> 8) & 0xFF;
                        int b = pixels[i] & 0xFF;

                        r = 255 - r;
                        g = 255 - g;
                        b = 255 - b;

                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    raster.SaveArgb32Pixels(rect, pixels);
                }

                var jpegOptions = new JpegOptions
                {
                    Quality = 85,
                    Source = new FileCreateSource(outputPath, false)
                };
                jp2Image.Save(outputPath, jpegOptions);
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
 * 1. When you need to read a large JPEG2000 file into memory, invert its colors, and output a smaller JPEG for web display.
 * 2. When processing medical or satellite JPEG2000 images on a server with limited memory, applying pixel‑wise transformations before saving as a standard JPEG.
 * 3. When converting archival JPEG2000 photos to JPEG while preserving a specific compression quality (85%) for compatibility with consumer applications.
 * 4. When performing batch image preprocessing in a C# service that requires loading images with a custom buffer size and applying custom pixel manipulation.
 * 5. When integrating Aspose.Imaging into a .NET workflow to transform high‑resolution JPEG2000 assets into web‑ready JPEGs with controlled quality and color adjustments.
 */
