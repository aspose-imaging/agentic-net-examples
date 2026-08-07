using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output folder for generated BMP files
            string outputFolder = @"C:\Temp\Circles";
            Directory.CreateDirectory(outputFolder);

            int canvasWidth = 200;
            int canvasHeight = 200;

            // Define distinct radii and corresponding colors
            var radii = new List<int> { 20, 40, 60 };
            var colors = new List<Color> { Color.Red, Color.Green, Color.Blue };

            for (int i = 0; i < radii.Count; i++)
            {
                int radius = radii[i];
                Color fillColor = colors[i];

                string outputPath = Path.Combine(outputFolder, $"circle_{radius}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound output file
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    // Calculate rectangle that bounds the centered circle
                    int centerX = canvasWidth / 2;
                    int centerY = canvasHeight / 2;
                    int rectX = centerX - radius;
                    int rectY = centerY - radius;
                    int diameter = radius * 2;

                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillEllipse(brush, new Rectangle(rectX, rectY, diameter, diameter));
                    }

                    // Save the bound image
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
 * 1. When a developer needs to create a set of placeholder icons in BMP format for a Windows desktop application, each showing a centered colored circle of different size to represent status levels.
 * 2. When generating test images for automated visual regression testing of image processing pipelines, using C# and Aspose.Imaging to produce BMP files with circles of varying radii and colors.
 * 3. When preparing sample assets for a tutorial on drawing shapes with the Aspose.Imaging Graphics API, requiring multiple BMP files that illustrate how FillEllipse works with different radii and fill colors.
 * 4. When building a batch job that creates printable calibration targets in BMP format, where each target is a centered colored circle of a specific radius to verify printer scaling.
 * 5. When exporting data points as simple visual markers in BMP files for integration with legacy systems that only accept bitmap images, using C# to draw circles of distinct sizes and colors for each data category.
 */