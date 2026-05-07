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
            // Output directory for generated BMP files
            string outputDir = @"C:\Temp\BmpBatch";
            Directory.CreateDirectory(outputDir);

            Random rnd = new Random();

            // Generate 5 BMP files with random line patterns
            for (int i = 0; i < 5; i++)
            {
                string outputPath = Path.Combine(outputDir, $"pattern_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with a file source
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                // Create a 500x500 BMP image
                using (Image image = Image.Create(options, 500, 500))
                {
                    // Draw random lines on the image
                    Graphics graphics = new Graphics(image);
                    int lineCount = 10;
                    for (int l = 0; l < lineCount; l++)
                    {
                        int x1 = rnd.Next(0, 500);
                        int y1 = rnd.Next(0, 500);
                        int x2 = rnd.Next(0, 500);
                        int y2 = rnd.Next(0, 500);
                        Color lineColor = Color.FromArgb(255, rnd.Next(256), rnd.Next(256), rnd.Next(256));
                        Pen pen = new Pen(lineColor, 2);
                        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
                    }

                    // Save the image (bound to the source)
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