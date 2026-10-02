// HOW-TO: Resize JPEG to Fit Viewport and Export as HTML5 Canvas in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output.html";
            int viewportWidth = 800;
            int viewportHeight = 600;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                double scale = Math.Min((double)viewportWidth / originalWidth, (double)viewportHeight / originalHeight);
                int newWidth = (int)(originalWidth * scale);
                int newHeight = (int)(originalHeight * scale);

                image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                Html5CanvasOptions options = new Html5CanvasOptions();

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
 * 1. When you need to display a high‑resolution photo on a web page inside a fixed‑size canvas without distortion, you can resize it to the viewport and save it as HTML5 Canvas.
 * 2. When building a responsive image gallery that must adapt large images to different screen dimensions, this code scales the image and outputs a canvas‑compatible HTML file.
 * 3. When converting legacy JPEG assets for use in HTML5 games or interactive demos, you can automatically fit them to the game’s viewport and embed them as canvas elements.
 * 4. When generating printable previews that must be shown in a browser’s canvas at a specific size, the snippet resizes the source and creates an HTML5 canvas representation.
 * 5. When automating batch processing of product photos to ensure they load quickly on mobile devices, you can scale each image to the target viewport and export it as a lightweight canvas HTML file.
 */
