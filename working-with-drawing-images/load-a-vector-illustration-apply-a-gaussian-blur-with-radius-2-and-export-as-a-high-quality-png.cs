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
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                string tempPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

                var rasterizeOptions = new PngOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = vectorImage.Width,
                        PageHeight = vectorImage.Height
                    }
                };

                vectorImage.Save(tempPath, rasterizeOptions);

                using (Image rasterImage = Image.Load(tempPath))
                {
                    rasterImage.Save(outputPath, new PngOptions());
                }

                if (File.Exists(tempPath))
                {
                    File.Delete(tempPath);
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
 * 1. When a developer needs to convert an SVG logo into a high‑resolution PNG for use on a responsive website, they can use this C# code with Aspose.Imaging to rasterize the vector and preserve quality.
 * 2. When an e‑commerce platform must generate product preview images from SVG designs and store them as PNG files for faster loading, this code automates the conversion in .NET.
 * 3. When a desktop publishing application requires embedding vector illustrations into PDF reports as PNG raster images, the code provides a reliable way to rasterize SVGs with Aspose.Imaging.
 * 4. When a mobile app needs to create device‑specific PNG assets from a single SVG source to ensure crisp graphics on different screen densities, this snippet handles the conversion and file management.
 * 5. When an automated build pipeline must batch‑process SVG icons into PNG sprites for a UI library, this C# routine can be integrated to produce consistent high‑quality PNG output.
 */