// HOW-TO: Adjust Gamma Of PSD And Save As PNG With Anti‑Aliasing In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.psd";
        string outputPath = "Output/enhanced.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image psdImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)psdImage;
                raster.AdjustGamma(0.8f);

                int width = psdImage.Width;
                int height = psdImage.Height;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Aspose.Imaging.Image pngCanvas = Aspose.Imaging.Image.Create(pngOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(pngCanvas);
                    graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;
                    graphics.DrawImage(psdImage, 0, 0);
                    pngCanvas.Save();
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
 * 1. When you need to darken or brighten a Photoshop PSD file programmatically before converting it to a web‑friendly PNG.
 * 2. When you want to improve the visual quality of a PSD‑to‑PNG conversion by applying anti‑aliasing during rendering.
 * 3. When an automated pipeline must standardize image gamma across multiple PSD assets for consistent color reproduction.
 * 4. When you are building a C# service that generates PNG previews of PSD files with smoother edges for UI thumbnails.
 * 5. When you need to batch‑process PSD designs, adjust their gamma, and export them as PNGs without manual Photoshop intervention.
 */
