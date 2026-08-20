// HOW-TO: Adjust Gamma and Apply Anti‑Alias Smoothing to PSD then Export as PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.psd";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustGamma(2.2f);

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        SmoothingMode = SmoothingMode.AntiAlias
                    }
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When you need to correct the brightness of a Photoshop PSD file for web display by adjusting its gamma and then save it as a lightweight PNG.
 * 2. When you want to improve the visual quality of vector‑based layers in a PSD by applying anti‑alias smoothing before converting to PNG for mobile apps.
 * 3. When an automated image‑processing pipeline must batch‑process PSD assets, normalize their gamma, and output PNGs for a content management system.
 * 4. When you are creating thumbnails from high‑resolution PSDs and need consistent gamma and smooth edges in the resulting PNG previews.
 * 5. When integrating Aspose.Imaging in a C# application to transform print‑ready PSD files into web‑friendly PNGs with gamma correction and anti‑alias rendering.
 */
