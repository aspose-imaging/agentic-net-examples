using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\concentric_circles.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Parameters for concentric circles
                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10; // margin
                int step = 20;
                bool useRed = true;

                // Draw circles with alternating colors
                for (int radius = maxRadius; radius > 0; radius -= step)
                {
                    Color fillColor = useRed ? Color.Red : Color.Blue;
                    useRed = !useRed;

                    int diameter = radius * 2;
                    int x = centerX - radius;
                    int y = centerY - radius;

                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillEllipse(brush, new Rectangle(x, y, diameter, diameter));
                    }
                }

                // Save the image (output file already bound)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}