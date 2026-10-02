// HOW-TO: Generate BMP Images with Centered Red Ellipse for Multiple Sizes in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputFolder = "OutputImages";
            Directory.CreateDirectory(outputFolder);

            var sizes = new List<(int width, int height)>
            {
                (200, 200),
                (300, 150),
                (400, 400)
            };

            foreach (var (width, height) in sizes)
            {
                string outputPath = Path.Combine(outputFolder, $"ellipse_{width}x{height}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    int ellipseWidth = width / 2;
                    int ellipseHeight = height / 2;
                    int x = (width - ellipseWidth) / 2;
                    int y = (height - ellipseHeight) / 2;
                    var rect = new Aspose.Imaging.Rectangle(x, y, ellipseWidth, ellipseHeight);

                    using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red))
                    {
                        graphics.FillEllipse(brush, rect);
                    }

                    image.Save();
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
 * 1. When you need to automatically create a set of BMP thumbnails each containing a centered red ellipse for different device resolutions.
 * 2. When generating placeholder graphics for UI mockups where each image size must match specific layout dimensions.
 * 3. When preparing test images for computer vision algorithms that require a consistent red ellipse shape across varied image sizes.
 * 4. When producing batch assets for a printing workflow that demands BMP files with a centered red ellipse as a branding mark.
 * 5. When scripting the creation of sample images for documentation or tutorials that illustrate Aspose.Imaging drawing capabilities in C#.
 */
