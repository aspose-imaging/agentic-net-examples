// HOW-TO: Apply Emboss Filter to PNG Texture at Runtime in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Assets/Textures/input.png";
        string outputPath = "Assets/Textures/output.png";

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
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to add a real‑time embossed effect to a character’s skin texture in a Unity game.
 * 2. When you want to preprocess UI button images with an emboss filter before saving them as PNG assets.
 * 3. When you must generate stylized terrain tiles on the fly by embossing height‑map textures during gameplay.
 * 4. When you are creating a dynamic post‑processing step that applies a 3×3 emboss convolution to any loaded sprite.
 * 5. When you need to automate the conversion of raw PNG assets into embossed versions for a retro‑style visual theme.
 */
