// HOW-TO: Reduce PSD Contrast by 20 Percent and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.psd";
        string outputPath = "Output/result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = image as Aspose.Imaging.RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                raster.AdjustContrast(-0.2f);

                var pngOptions = new PngOptions();
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
 * 1. When a web designer needs to tone down the contrast of a Photoshop PSD before publishing it as a lightweight PNG for faster page loads.
 * 2. When an automated build pipeline must batch‑process PSD assets, lowering their contrast by 20 % to match a brand’s muted visual style and then export them to PNG for use in mobile apps.
 * 3. When a digital archivist wants to preserve original PSD files while creating lower‑contrast PNG previews for quick browsing in a catalog.
 * 4. When a game developer needs to reduce the harshness of UI textures stored in PSD format and convert them to PNG for inclusion in the game’s asset bundle.
 * 5. When a content management system integrates Aspose.Imaging to dynamically adjust PSD image contrast and deliver PNG thumbnails to end users.
 */
