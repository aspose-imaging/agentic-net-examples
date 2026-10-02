// HOW-TO: Apply Perspective Distortion to SVG and Export High-Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                int outWidth = 2000;
                int outHeight = 1000;

                using (RasterImage canvas = (RasterImage)Image.Create(
                    new PngOptions { Source = new FileCreateSource(outputPath, false) },
                    outWidth, outHeight))
                {
                    // Fill background with white
                    canvas.SavePixels(
                        new Rectangle(0, 0, outWidth, outHeight),
                        Enumerable.Repeat(Color.White, outWidth * outHeight).ToArray());

                    // Draw the vector image onto the raster canvas
                    Graphics graphics = new Graphics(canvas);
                    var matrix = new Matrix(1, 0.2f, -0.2f, 1, 0, 0);
                    graphics.Transform = matrix;
                    graphics.DrawImage(vectorImage, new Rectangle(0, 0, outWidth, outHeight));

                    // Save the rasterized image as PNG
                    canvas.Save();
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
 * 1. When you need to generate a billboard‑style image from an SVG logo for large‑format printing, you can apply a perspective matrix and export a high‑resolution PNG using Aspose.Imaging in C#.
 * 2. When creating mock‑ups of advertisements where a vector graphic must appear tilted on a street‑level photograph, this code rasterizes the SVG with a custom transform and saves it as a PNG.
 * 3. When a web service must convert user‑uploaded SVG icons into high‑density PNG thumbnails that simulate a 3‑D view, the example shows how to perform the distortion and rasterization in .NET.
 * 4. When preparing assets for a digital signage system that requires PNG files with a specific perspective to match the screen angle, the code demonstrates loading the SVG, applying a matrix, and saving the result.
 * 5. When automating batch processing of vector drawings to produce printable PNGs with a simulated billboard perspective, this snippet provides the C# workflow using Aspose.Imaging’s graphics and matrix features.
 */
