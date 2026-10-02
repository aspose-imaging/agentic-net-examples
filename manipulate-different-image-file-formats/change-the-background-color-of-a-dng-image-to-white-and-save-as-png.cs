// HOW-TO: Convert DNG to PNG with White Background Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\image.dng";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage source = (RasterImage)Image.Load(inputPath))
            {
                int width = source.Width;
                int height = source.Height;
                var rect = new Rectangle(0, 0, width, height);

                using (RasterImage canvas = (RasterImage)Image.Create(new PngOptions(), width, height))
                {
                    int[] whitePixels = new int[width * height];
                    for (int i = 0; i < whitePixels.Length; i++)
                    {
                        whitePixels[i] = unchecked((int)0xFFFFFFFF);
                    }
                    canvas.SaveArgb32Pixels(rect, whitePixels);

                    int[] srcPixels = source.LoadArgb32Pixels(rect);
                    canvas.SaveArgb32Pixels(rect, srcPixels);

                    canvas.Save(outputPath, new PngOptions());
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
 * 1. When you need to display raw DNG photos on a web page that only supports PNG, you can convert them and replace the transparent background with white.
 * 2. When preparing product images captured in raw format for e‑commerce catalogs, you can ensure a consistent white backdrop by converting DNG to PNG with a white background.
 * 3. When automating a batch workflow that ingests camera raw files and generates printable PNG assets, you can use this code to set a solid white canvas before saving.
 * 4. When integrating raw image processing into a C# desktop application that requires PNG output for further editing, the code lets you eliminate transparency by filling the background with white.
 * 5. When creating thumbnails for a digital asset management system that stores only PNG files, you can convert each DNG and enforce a white background to avoid visual artifacts.
 */
