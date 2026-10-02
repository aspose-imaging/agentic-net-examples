// HOW-TO: Create Grayscale PSD from JPEG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                int width = raster.Width;
                int height = raster.Height;

                PsdOptions options = new PsdOptions();
                options.Source = new FileCreateSource(outputPath, false);
                options.ColorMode = ColorModes.Grayscale;

                using (Image psd = Image.Create(options, width, height))
                {
                    RasterImage psdRaster = (RasterImage)psd;

                    if (!raster.IsCached) raster.CacheData();
                    if (!psdRaster.IsCached) psdRaster.CacheData();

                    Rectangle rect = new Rectangle(0, 0, width, height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);
                    psdRaster.SaveArgb32Pixels(rect, pixels);
                    psd.Save();
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
 * 1. When you need to convert a color JPEG to a monochrome PSD for printing workflows.
 * 2. When you want to generate a grayscale PSD to reduce file size while preserving image detail.
 * 3. When an automated batch process must create PSD files that are compatible with legacy Photoshop grayscale mode.
 * 4. When a web service needs to deliver PSD assets with a single channel for scientific imaging.
 * 5. When a desktop application must export user‑uploaded photos as grayscale PSDs for further editing in Photoshop.
 */
