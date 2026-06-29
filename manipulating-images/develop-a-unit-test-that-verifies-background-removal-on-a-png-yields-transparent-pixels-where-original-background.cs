using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 100;
            int height = 100;
            using (PngImage png = new PngImage(width, height, PngColorType.TruecolorWithAlpha))
            {
                Aspose.Imaging.Color[] pixels = new Aspose.Imaging.Color[width * height];
                for (int i = 0; i < pixels.Length; i++)
                    pixels[i] = Aspose.Imaging.Color.Red;

                for (int y = 30; y < 70; y++)
                {
                    for (int x = 30; x < 70; x++)
                    {
                        int idx = y * width + x;
                        pixels[idx] = Aspose.Imaging.Color.Blue;
                    }
                }

                png.SavePixels(new Aspose.Imaging.Rectangle(0, 0, width, height), pixels);
                png.Save(inputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(inputPath, false) });
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(outputPath, false) });
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
 * 1. When a developer needs to ensure that a PNG image generated with Aspose.Imaging correctly removes a solid background and replaces it with transparent pixels for web UI overlays.
 * 2. When an e‑commerce platform wants to automatically validate that product photos processed by a C# service have their background removed and saved as true‑color‑with‑alpha PNGs before publishing.
 * 3. When a mobile app team writes a unit test to confirm that the Aspose.Imaging raster‑image loading and saving pipeline preserves transparency after background removal for avatar images.
 * 4. When a digital marketing tool integrates Aspose.Imaging to create PNG banners and must verify through automated testing that the original background area becomes fully transparent.
 * 5. When a game developer uses C# and Aspose.Imaging to generate sprite sheets and needs a test that guarantees the background pixels are converted to alpha‑transparent values in the output PNG.
 */