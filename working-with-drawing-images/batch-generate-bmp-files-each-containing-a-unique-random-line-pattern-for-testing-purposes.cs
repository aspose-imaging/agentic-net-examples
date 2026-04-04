using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output directory for generated BMP files
        string outputDir = @"C:\Temp\BmpLines";
        // Ensure the directory exists
        Directory.CreateDirectory(outputDir);

        int imageCount = 5;          // Number of BMP files to generate
        int width = 500;             // Canvas width
        int height = 500;            // Canvas height
        int linesPerImage = 10;      // Number of random lines per image
        Random rand = new Random();

        for (int i = 0; i < imageCount; i++)
        {
            string outputPath = Path.Combine(outputDir, $"line_{i}.bmp");
            // Ensure the directory for this output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);
            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions()
            {
                Source = source,
                BitsPerPixel = 24
            };

            // Create the BMP canvas
            using (Image canvas = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.White);

                // Draw random lines
                for (int l = 0; l < linesPerImage; l++)
                {
                    // Random color for each line
                    Color lineColor = Color.FromArgb(255, rand.Next(256), rand.Next(256), rand.Next(256));
                    Pen pen = new Pen(lineColor, 2);
                    Point start = new Point(rand.Next(width), rand.Next(height));
                    Point end = new Point(rand.Next(width), rand.Next(height));
                    graphics.DrawLine(pen, start, end);
                }

                // Save the bound image
                canvas.Save();
            }
        }
    }
}