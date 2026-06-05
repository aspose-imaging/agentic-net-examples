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
            string inputPath = @"C:\temp\input.bmp";
            string outputPath = @"C:\temp\output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Ensure the image is a raster image for pixel manipulation
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    // Load pixel data
                    Aspose.Imaging.Color[] pixels = raster.LoadPixels(raster.Bounds);
                    int[] invertedArgb = new int[pixels.Length];

                    for (int i = 0; i < pixels.Length; i++)
                    {
                        var c = pixels[i];
                        int a = c.A;
                        int r = 255 - c.R;
                        int g = 255 - c.G;
                        int b = 255 - c.B;
                        invertedArgb[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    // Save the inverted pixels back to the image
                    raster.SaveArgb32Pixels(raster.Bounds, invertedArgb);
                }

                // Save the (now inverted) image as SVG
                image.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}