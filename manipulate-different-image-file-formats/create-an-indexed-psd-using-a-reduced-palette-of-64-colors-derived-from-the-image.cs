// HOW-TO: Create Indexed PSD With 64‑Color Palette From PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
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
            string inputPath = "Input\\source.png";
            string outputPath = "Output\\result.psd";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image srcImage = Image.Load(inputPath))
            {
                RasterImage raster;
                if (srcImage is RasterCachedImage rci)
                {
                    if (!rci.IsCached) rci.CacheData();
                    raster = rci;
                }
                else
                {
                    raster = srcImage as RasterImage;
                }

                Rectangle rect = new Rectangle(0, 0, raster.Width, raster.Height);
                int[] argbPixels = new int[raster.Width * raster.Height];
                raster.SaveArgb32Pixels(rect, argbPixels);

                var distinctColors = new HashSet<int>(argbPixels);
                var paletteColors = distinctColors.Take(64).Select(c => Color.FromArgb(c)).ToArray();
                ColorPalette palette = new ColorPalette(paletteColors);

                using (PsdOptions psdOptions = new PsdOptions())
                {
                    psdOptions.Source = new FileCreateSource(outputPath, false);
                    psdOptions.ColorMode = ColorModes.Indexed;
                    psdOptions.Palette = palette;

                    using (Image psdImage = Image.Create(psdOptions, raster.Width, raster.Height))
                    {
                        Graphics graphics = new Graphics(psdImage);
                        graphics.DrawImage(raster, 0, 0);
                        psdImage.Save();
                    }
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
 * 1. When you need to shrink a Photoshop file by converting a full‑color PNG into an indexed PSD limited to 64 colors to reduce storage size.
 * 2. When exporting graphics for legacy game engines that only accept indexed PSD files with a maximum palette of 64 colors.
 * 3. When preparing images for a printing workflow that requires indexed color mode to guarantee consistent color output across devices.
 * 4. When generating thumbnails or preview images where a fixed 64‑color palette minimizes memory usage while retaining the original visual appearance.
 * 5. When automating a batch process that converts PNG assets to indexed PSDs to meet a design pipeline’s strict palette‑size specifications.
 */
