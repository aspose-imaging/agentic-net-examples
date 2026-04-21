using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output directory and file names
        string outputDir = @"C:\Temp\BmpBatch";
        string[] outputFiles = new string[]
        {
            Path.Combine(outputDir, "pattern1.bmp"),
            Path.Combine(outputDir, "pattern2.bmp"),
            Path.Combine(outputDir, "pattern3.bmp"),
            Path.Combine(outputDir, "pattern4.bmp"),
            Path.Combine(outputDir, "pattern5.bmp")
        };

        // Image dimensions
        int width = 200;
        int height = 200;

        // Random generator for line positions and colors
        Random rnd = new Random();

        foreach (string outputPath in outputFiles)
        {
            // Ensure the output directory exists for each file
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a bound BMP image using FileCreateSource and BmpOptions
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions()
            {
                Source = source,
                BitsPerPixel = 24
            };

            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Create a Graphics object for drawing (no using)
                Graphics graphics = new Graphics(canvas);
                // Clear background to white
                graphics.Clear(Color.White);

                // Draw a random number of lines (e.g., 10)
                for (int i = 0; i < 10; i++)
                {
                    // Random start and end points within the canvas bounds
                    Point start = new Point(rnd.Next(width), rnd.Next(height));
                    Point end = new Point(rnd.Next(width), rnd.Next(height));

                    // Random color
                    Color lineColor = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));

                    // Random pen width (1 to 5)
                    int penWidth = rnd.Next(1, 6);

                    // Create Pen (no using)
                    Pen pen = new Pen(lineColor, penWidth);
                    graphics.DrawLine(pen, start, end);
                }

                // Save the bound image (no need to specify options again)
                canvas.Save();
            }
        }
    }
}