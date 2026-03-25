using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.bmp";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image as RasterImage
        using (RasterImage bmp = (RasterImage)Image.Load(inputPath))
        {
            // Load pixel data (ARGB)
            int[] pixels = bmp.LoadArgb32Pixels(bmp.Bounds);

            // Invert colors (preserve alpha)
            for (int i = 0; i < pixels.Length; i++)
            {
                int p = pixels[i];
                int a = (p >> 24) & 0xFF;
                int rgb = p & 0x00FFFFFF;
                int invRgb = (~rgb) & 0x00FFFFFF;
                pixels[i] = (a << 24) | invRgb;
            }

            // Apply inverted pixels back to the image
            bmp.SaveArgb32Pixels(bmp.Bounds, pixels);

            // Prepare SVG save options with rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = bmp.Size
                }
            };

            // Save the inverted image as SVG
            bmp.Save(outputPath, svgOptions);
        }
    }
}