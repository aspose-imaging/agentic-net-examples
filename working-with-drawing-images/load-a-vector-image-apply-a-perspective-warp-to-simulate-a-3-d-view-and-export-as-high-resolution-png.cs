// HOW-TO: Apply Perspective Warp to EPS and Export High-Resolution PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\warped.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = 2000;
                int height = 2000;

                PngOptions pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image canvas = Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    Point[] destPoints = new Point[]
                    {
                        new Point(0, 0),
                        new Point(width, 0),
                        new Point((int)(width * 0.2), height)
                    };

                    graphics.DrawImage(vectorImage, destPoints);
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
 * 1. When you need to convert a vector EPS logo into a high‑resolution PNG with a simulated 3‑D angle for web or print layouts.
 * 2. When you want to render a scalable illustration as a raster image while applying a perspective distortion to fit a brochure’s slanted design.
 * 3. When an e‑commerce platform requires product diagrams in PNG format that appear tilted to match a 3‑D product view.
 * 4. When you must generate thumbnails of engineering drawings with a custom perspective for a CAD review portal.
 * 5. When a reporting tool needs to embed EPS charts as high‑quality PNGs with a forced viewpoint to align with other visual elements.
 */
