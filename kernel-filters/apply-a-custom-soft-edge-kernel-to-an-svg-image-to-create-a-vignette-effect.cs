using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load rasterized image and apply custom soft‑edge kernel
            using (Image rasterImg = Image.Load(tempPath))
            {
                RasterImage raster = (RasterImage)rasterImg;

                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
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
 * 1. When a web developer wants to add a subtle vignette effect to a company logo stored as an SVG before embedding it in a marketing email, they can rasterize the SVG to PNG and apply a custom soft‑edge convolution kernel using Aspose.Imaging for .NET.
 * 2. When a mobile app needs to generate thumbnail previews of user‑uploaded SVG illustrations with a softened border for a polished UI, the code can convert the SVG to a raster image and apply the soft‑edge filter in C#.
 * 3. When an e‑learning platform requires consistent visual styling by adding a gentle vignette to SVG diagrams that are later displayed as PNGs in course materials, this approach automates the rasterization and edge‑softening process.
 * 4. When a desktop publishing tool must batch‑process SVG icons to create PNG assets with a smooth fade‑out around the edges for use in UI skins, the code provides a repeatable way to rasterize and filter each file.
 * 5. When a game developer needs to pre‑render SVG textures with a soft border to avoid harsh clipping when composited in the game engine, they can use this Aspose.Imaging workflow to produce PNGs with a vignette effect.
 */