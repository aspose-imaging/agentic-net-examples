// HOW-TO: Resize PNG to Half Size and Apply Emboss Filter in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;
                raster.Resize(newWidth, newHeight);

                raster.Filter(raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to generate smaller, stylized thumbnails of PNG graphics for a web gallery, you can resize the image and add an emboss effect in a single C# routine.
 * 2. When preparing product images for a mobile app, developers may shrink the original PNG to half its dimensions and apply an emboss filter to enhance visual depth without increasing file size.
 * 3. When creating printable mock‑ups that require a subtle 3‑D look, you can use Aspose.Imaging in C# to downscale a PNG and automatically emboss it before saving.
 * 4. When optimizing assets for an e‑learning platform, you might need to reduce PNG resolution and add a texture‑like emboss effect to improve readability on low‑resolution screens.
 * 5. When building an automated image‑processing pipeline that adds artistic effects, the code lets you batch‑process PNG files by resizing them and applying the Emboss3x3 convolution filter in C#.
 */
