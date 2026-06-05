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
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Ensure the image is cached for pixel access
                    if (image is RasterCachedImage rci && !rci.IsCached)
                    {
                        rci.CacheData();
                    }

                    RasterImage raster = (RasterImage)image;
                    int width = raster.Width;
                    int height = raster.Height;

                    // Load pixel data
                    int[] pixels = raster.LoadArgb32Pixels(new Rectangle(0, 0, width, height));

                    // Invert colors
                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int argb = pixels[i];
                        byte a = (byte)((argb >> 24) & 0xFF);
                        byte r = (byte)((argb >> 16) & 0xFF);
                        byte g = (byte)((argb >> 8) & 0xFF);
                        byte b = (byte)(argb & 0xFF);

                        r = (byte)(255 - r);
                        g = (byte)(255 - g);
                        b = (byte)(255 - b);

                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    // Save modified pixels back to the image
                    raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);

                    // Prepare SVG save options
                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        var vectorOptions = new SvgRasterizationOptions
                        {
                            PageSize = raster.Size
                        };
                        svgOptions.VectorRasterizationOptions = vectorOptions;

                        // Save as SVG
                        raster.Save(outputPath, svgOptions);
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