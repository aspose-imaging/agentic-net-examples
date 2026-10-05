// HOW-TO: Create a Solid Color JPEG Image from Pixel Array in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 600;
            Color bgColor = Color.FromArgb(255, 0, 128, 255);
            int bgArgb = bgColor.ToArgb();

            JpegOptions options = new JpegOptions();
            using (Image image = Image.Create(options, width, height))
            {
                RasterImage raster = (RasterImage)image;
                int[] pixels = new int[width * height];
                for (int i = 0; i < pixels.Length; i++)
                {
                    pixels[i] = bgArgb;
                }
                raster.SaveArgb32Pixels(new Rectangle(0, 0, width, height), pixels);
                raster.Save(outputPath, options);
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
 * 1. When you need to generate a blank JPEG placeholder with a specific background color for dynamic image generation in a web application.
 * 2. When you want to programmatically create a JPEG thumbnail of a fixed size filled with a brand color before adding overlay graphics.
 * 3. When you must produce a JPEG file for testing image pipelines that requires a known ARGB background without loading an existing picture.
 * 4. When you are building a reporting tool that inserts a solid‑color JPEG as a background layer for charts or diagrams.
 * 5. When you need to allocate pixel data manually to control memory usage while creating a JPEG image in a high‑performance C# service.
 */
