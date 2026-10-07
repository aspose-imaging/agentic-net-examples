// HOW-TO: Adjust TIFF Contrast And Apply Floyd Steinberg Dithering To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output\\result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (TiffImage tiff = (TiffImage)Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)tiff;
                raster.AdjustContrast(1.2f);
                raster.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8);

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to improve the visual clarity of a scanned TIFF document before converting it to a web‑friendly PNG, you can adjust its contrast and apply Floyd‑Steinberg dithering in C#.
 * 2. When preparing high‑resolution medical or engineering TIFF images for display on low‑color‑depth devices, you can reduce the contrast range and dither them to an 8‑bit PNG using Aspose.Imaging.
 * 3. When automating a batch process that converts legacy TIFF assets to PNG while preserving detail through contrast enhancement and error‑diffusion dithering, this code provides a reliable solution.
 * 4. When generating printable PNG thumbnails from large TIFF files and need to maintain sharp edges on limited palettes, applying contrast adjustment followed by Floyd‑Steinberg dithering ensures quality results.
 * 5. When integrating image preprocessing into a C# application that receives TIFF uploads and must output optimized PNGs for web galleries, the contrast and dithering steps help reduce file size without sacrificing visual fidelity.
 */
