// HOW-TO: Batch Invert BMP Images and Save as SVG with Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                if (!Path.GetExtension(inputPath).Equals(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".svg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    Rectangle rect = new Rectangle(0, 0, raster.Width, raster.Height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);

                    for (int i = 0; i < pixels.Length; i++)
                    {
                        int pixel = pixels[i];
                        int a = (pixel >> 24) & 0xFF;
                        int r = 255 - ((pixel >> 16) & 0xFF);
                        int g = 255 - ((pixel >> 8) & 0xFF);
                        int b = 255 - (pixel & 0xFF);
                        pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                    }

                    raster.SaveArgb32Pixels(rect, pixels);

                    using (SvgOptions svgOptions = new SvgOptions())
                    {
                        SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                        {
                            PageWidth = raster.Width,
                            PageHeight = raster.Height,
                            BackgroundColor = Color.White
                        };
                        svgOptions.VectorRasterizationOptions = rasterOptions;

                        raster.Save(outputPath, svgOptions);
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
 * 1. When a developer needs to automatically convert a folder of legacy BMP graphics into inverted‑color SVG vectors for web display.
 * 2. When an application must preprocess scanned BMP icons by applying a negative filter before embedding them in scalable SVG assets.
 * 3. When a batch job has to generate high‑contrast SVG versions of BMP screenshots for accessibility testing.
 * 4. When a game‑modding tool requires converting BMP texture files to inverted SVG outlines for UI overlays.
 * 5. When a reporting system must transform BMP charts into color‑inverted SVG diagrams to match a dark‑theme style.
 */
