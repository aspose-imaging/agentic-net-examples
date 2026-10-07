// HOW-TO: Convert BMP to SVG with Red‑Channel Grayscale Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
                outputDir = ".";
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int width = raster.Width;
                int height = raster.Height;

                int[] pixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    // Custom color filter: map to grayscale based on red channel
                    int newR = r;
                    int newG = r;
                    int newB = r;
                    pixels[i] = (a << 24) | (newR << 16) | (newG << 8) | newB;
                }

                raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                SvgOptions svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to transform a legacy BMP icon into a scalable SVG while applying a red‑channel based grayscale effect for consistent web display.
 * 2. When generating vector graphics from raster scans and you want to preserve transparency while simplifying colors to a single channel using Aspose.Imaging in C#.
 * 3. When creating printable assets that require SVG output but the source images are BMP files and you need a custom color mapping to match brand guidelines.
 * 4. When automating a batch conversion pipeline that converts BMP screenshots to lightweight SVG files with a grayscale filter to reduce file size and improve loading speed.
 * 5. When integrating image processing into a .NET application that must read BMP data, apply a custom filter, and export the result as an SVG for use in responsive UI components.
 */
