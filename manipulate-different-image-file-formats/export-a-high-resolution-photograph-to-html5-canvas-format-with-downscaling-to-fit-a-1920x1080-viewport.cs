// HOW-TO: Export High Resolution Photo to HTML5 Canvas Scaled for 1920x1080 in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int maxWidth = 1920;
                int maxHeight = 1080;

                double widthRatio = (double)maxWidth / image.Width;
                double heightRatio = (double)maxHeight / image.Height;
                double scale = Math.Min(1.0, Math.Min(widthRatio, heightRatio));

                int newWidth = (int)(image.Width * scale);
                int newHeight = (int)(image.Height * scale);

                if (scale < 1.0)
                {
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);
                }

                Html5CanvasOptions options = new Html5CanvasOptions()
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                image.Save(outputPath, options);
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
 * 1. When you need to embed a large JPEG image in a web page using an HTML5 canvas without loading the full‑size file, you can downscale it to 1920×1080 and save it as a canvas HTML file.
 * 2. When creating a photo‑gallery application that generates offline HTML5 canvas previews of high‑resolution pictures for faster client rendering.
 * 3. When optimizing images for a responsive web design that limits the viewport to 1080p, you can programmatically resize and export them to HTML5 canvas format in C#.
 * 4. When building a reporting tool that embeds high‑quality photographs directly into HTML reports via canvas elements, ensuring the images fit within a standard HD display.
 * 5. When automating batch conversion of RAW or JPEG photos to HTML5 canvas files for use in interactive tutorials or e‑learning modules that require a fixed 1920×1080 canvas size.
 */
