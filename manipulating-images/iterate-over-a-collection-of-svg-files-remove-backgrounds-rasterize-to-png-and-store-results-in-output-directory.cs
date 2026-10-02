// HOW-TO: Batch Remove Background From SVG and Convert To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = "input_svgs";
            string outputDir = "output_pngs";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string[] svgFiles = Directory.GetFiles(inputDir, "*.svg");

            foreach (string inputPath in svgFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    var vectorImage = image as VectorImage;
                    if (vectorImage != null)
                    {
                        vectorImage.RemoveBackground(new RemoveBackgroundSettings());
                    }

                    var pngOptions = new PngOptions()
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        VectorRasterizationOptions = new VectorRasterizationOptions()
                        {
                            BackgroundColor = Color.Transparent,
                            PageSize = image.Size
                        }
                    };

                    image.Save(outputPath, pngOptions);
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
 * 1. When you need to automatically strip unwanted backgrounds from a large set of SVG icons before using them on a transparent web UI.
 * 2. When you want to generate high‑quality PNG assets from vector SVG logos for inclusion in mobile apps that require raster images.
 * 3. When a CI/CD pipeline must process design files, removing backgrounds and converting them to PNGs for automated documentation builds.
 * 4. When you are preparing product catalog images by converting vendor‑supplied SVG drawings to PNG thumbnails with transparent backgrounds.
 * 5. When you need to batch‑process SVG diagrams for email newsletters, ensuring they render correctly as PNGs without any background color.
 */
