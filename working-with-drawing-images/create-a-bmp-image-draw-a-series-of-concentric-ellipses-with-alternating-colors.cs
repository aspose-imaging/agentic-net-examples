using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\concentric_ellipses.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 500;
            int height = 500;
            int ellipseCount = 6;
            int marginStep = 20;

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw concentric ellipses with alternating colors
                for (int i = 0; i < ellipseCount; i++)
                {
                    int margin = i * marginStep;
                    float rectX = margin;
                    float rectY = margin;
                    float rectWidth = width - 2 * margin;
                    float rectHeight = height - 2 * margin;

                    // Alternate between Red and Blue
                    Aspose.Imaging.Color penColor = (i % 2 == 0) ? Aspose.Imaging.Color.Red : Aspose.Imaging.Color.Blue;
                    Pen pen = new Pen(penColor, 2);

                    // Draw the ellipse
                    graphics.DrawEllipse(pen, new RectangleF(rectX, rectY, rectWidth, rectHeight));
                }

                // Save the image (writes to the path specified in FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}