// HOW-TO: Preserve PNG Transparency While Applying Emboss3x3 Filter In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var bounds = raster.Bounds;

                int[] originalPixels = raster.LoadArgb32Pixels(bounds);
                int pixelCount = originalPixels.Length;
                byte[] alphas = new byte[pixelCount];
                int[] rgbPixels = new int[pixelCount];

                for (int i = 0; i < pixelCount; i++)
                {
                    alphas[i] = (byte)(originalPixels[i] >> 24);
                    rgbPixels[i] = (0xFF << 24) | (originalPixels[i] & 0x00FFFFFF);
                }

                raster.SaveArgb32Pixels(bounds, rgbPixels);
                raster.Filter(bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                int[] filteredPixels = raster.LoadArgb32Pixels(bounds);
                for (int i = 0; i < pixelCount; i++)
                {
                    filteredPixels[i] = (alphas[i] << 24) | (filteredPixels[i] & 0x00FFFFFF);
                }
                raster.SaveArgb32Pixels(bounds, filteredPixels);

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, options);
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
 * 1. When you need to apply an emboss effect to a PNG logo and keep its transparent background intact.
 * 2. When processing user‑uploaded PNG avatars in a C# web service and must preserve the alpha channel after a convolution filter.
 * 3. When generating stylized thumbnails for a website and require the PNG’s transparent edges to remain after applying the Emboss3x3 filter.
 * 4. When creating game sprites that need an embossed appearance while retaining per‑pixel opacity using Aspose.Imaging for .NET.
 * 5. When automating batch conversion of PNG assets for marketing materials and want to maintain transparency after applying image filters.
 */
