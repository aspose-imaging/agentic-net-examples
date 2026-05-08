using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Apply sharpen filter (convolution)
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Retrieve ARGB pixels
                int[] pixels = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);

                // Round and clamp each channel
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = (argb >> 16) & 0xFF;
                    int g = (argb >> 8) & 0xFF;
                    int b = argb & 0xFF;

                    // Convert to double for rounding (simulating post‑convolution values)
                    double rd = Math.Round((double)r);
                    double gd = Math.Round((double)g);
                    double bd = Math.Round((double)b);

                    // Clamp to 0‑255
                    int rc = (int)Math.Max(0, Math.Min(255, rd));
                    int gc = (int)Math.Max(0, Math.Min(255, gd));
                    int bc = (int)Math.Max(0, Math.Min(255, bd));

                    // Reassemble ARGB
                    pixels[i] = (a << 24) | (rc << 16) | (gc << 8) | bc;
                }

                // Save the modified pixels
                rasterImage.SaveArgb32Pixels(rasterImage.Bounds, pixels);
                rasterImage.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}