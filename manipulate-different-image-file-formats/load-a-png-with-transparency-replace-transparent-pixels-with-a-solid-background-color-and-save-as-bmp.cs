// HOW-TO: Replace Transparent Pixels In PNG With White Background And Save As BMP In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);

                int bgColor = Aspose.Imaging.Color.FromArgb(255, 255, 255, 255).ToArgb();

                for (int i = 0; i < pixels.Length; i++)
                {
                    int alpha = (pixels[i] >> 24) & 0xFF;
                    if (alpha == 0)
                    {
                        pixels[i] = bgColor;
                    }
                }

                raster.SaveArgb32Pixels(raster.Bounds, pixels);
                raster.Save(outputPath, new BmpOptions());
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
 * 1. When you need to convert a PNG logo with transparent areas into a BMP for legacy Windows applications that do not support alpha channels.
 * 2. When preparing images for printing where the printer requires a solid background and BMP format, you can replace transparent pixels with a chosen color using Aspose.Imaging in C#.
 * 3. When generating thumbnails for a report that must be embedded in a Word document as BMP files, you can fill transparent regions with white before saving.
 * 4. When migrating assets from a web project to a desktop application that only reads BMP files, you can remove PNG transparency by substituting it with a solid color.
 * 5. When automating batch processing of UI icons to ensure consistent background color across all BMP resources, this code replaces any fully transparent pixels with the specified color.
 */
