using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"c:\temp\shapes_output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas (800x600)
        using (Image image = Image.Create(pngOptions, 800, 600))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Collection of drawing actions representing different shapes
            var drawActions = new List<Action<Graphics>>
            {
                // Draw a red line
                g => g.DrawLine(new Pen(Color.Red, 3), new Point(50, 50), new Point(200, 50)),

                // Draw a blue rectangle
                g => g.DrawRectangle(new Pen(Color.Blue, 2), new Rectangle(100, 100, 150, 100)),

                // Draw a green ellipse
                g => g.DrawEllipse(new Pen(Color.Green, 2), new Rectangle(300, 200, 120, 80)),

                // Draw a purple polygon
                g => g.DrawPolygon(new Pen(Color.Purple, 2), new[]
                {
                    new Point(400, 300),
                    new Point(450, 350),
                    new Point(400, 400),
                    new Point(350, 350)
                })
            };

            // Iterate over the collection and execute each drawing action
            foreach (var action in drawActions)
            {
                action(graphics);
            }

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}