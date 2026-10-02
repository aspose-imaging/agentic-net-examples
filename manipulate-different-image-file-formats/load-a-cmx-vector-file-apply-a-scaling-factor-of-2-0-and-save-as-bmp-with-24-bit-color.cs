// HOW-TO: Scale CMX Vector by 2x and Save as 24‑Bit BMP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int newWidth = (int)(cmx.Width * 2.0);
                int newHeight = (int)(cmx.Height * 2.0);

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;

                using (Image raster = Image.Create(bmpOptions, newWidth, newHeight))
                {
                    Graphics graphics = new Graphics(raster);
                    graphics.DrawImage(cmx, new Rectangle(0, 0, newWidth, newHeight));

                    raster.Save(outputPath, bmpOptions);
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
 * 1. When you need to convert legacy CorelDRAW CMX drawings into high‑resolution BMP files for printing or archival purposes.
 * 2. When a Windows desktop application must display a CMX illustration at double size on a bitmap canvas.
 * 3. When generating thumbnails for CMX assets by scaling them and saving as 24‑bit BMP for compatibility with older image viewers.
 * 4. When preparing CMX graphics for inclusion in a .NET reporting tool that only accepts BMP images.
 * 5. When automating batch processing of CMX files to produce larger, lossless BMP copies for machine‑vision analysis.
 */
