// HOW-TO: Create Multiple BMP Images With Colored Backgrounds And Centered Ellipse In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output directory
            string outputDir = @"C:\Temp\BmpBatch";
            Directory.CreateDirectory(outputDir);

            // List of background colors and corresponding file names
            var items = new List<(string FileName, Aspose.Imaging.Color BgColor)>
            {
                ("red.bmp", Aspose.Imaging.Color.Red),
                ("green.bmp", Aspose.Imaging.Color.Green),
                ("blue.bmp", Aspose.Imaging.Color.Blue),
                ("yellow.bmp", Aspose.Imaging.Color.Yellow),
                ("purple.bmp", Aspose.Imaging.Color.Purple)
            };

            int canvasWidth = 400;
            int canvasHeight = 400;
            int ellipseWidth = 200;
            int ellipseHeight = 200;
            int ellipseX = (canvasWidth - ellipseWidth) / 2;
            int ellipseY = (canvasHeight - ellipseHeight) / 2;

            foreach (var (fileName, bgColor) in items)
            {
                string outputPath = Path.Combine(outputDir, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound file source
                BmpOptions options = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, canvasWidth, canvasHeight))
                {
                    // Draw background and centered black ellipse
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                    graphics.Clear(bgColor);
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                    graphics.DrawEllipse(pen, ellipseX, ellipseY, ellipseWidth, ellipseHeight);

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
 * 1. When you need to generate a set of BMP icons with different theme colors for a Windows desktop application's toolbar.
 * 2. When creating test assets for image‑processing pipelines that require uniform size images with a known shape overlay.
 * 3. When preparing colored placeholders with a central ellipse for UI mockups or documentation screenshots.
 * 4. When automating the production of printable labels that use a solid background color and a centered logo shape.
 * 5. When building a batch of sprite sheets where each frame has a distinct background hue and a consistent black ellipse for game development.
 */
