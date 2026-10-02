// HOW-TO: Check PSD Transparency Before Saving as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image psdImage = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)psdImage)
                {
                    bool hasTransparency = false;
                    for (int y = 0; y < raster.Height && !hasTransparency; y++)
                    {
                        for (int x = 0; x < raster.Width; x++)
                        {
                            var color = raster.GetPixel(x, y);
                            if (color.A < 255)
                            {
                                hasTransparency = true;
                                break;
                            }
                        }
                    }

                    if (!hasTransparency)
                    {
                        Console.WriteLine("The image does not contain transparency. Saving aborted.");
                        return;
                    }

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    raster.Save(outputPath, pngOptions);
                }
            }

            Console.WriteLine("PNG saved with transparency.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to ensure a Photoshop PSD file contains alpha channel data before converting it to a PNG for web use.
 * 2. When you want to abort the PNG export if the source PSD has no transparent pixels, preventing unnecessary file creation.
 * 3. When building an automated asset pipeline that validates transparency in layered designs before publishing them as PNG assets.
 * 4. When generating thumbnails from PSD files and must preserve only images that include transparent regions for UI overlays.
 * 5. When performing quality checks on batch‑converted images to guarantee that PNG outputs retain the original PSD’s transparency information.
 */
