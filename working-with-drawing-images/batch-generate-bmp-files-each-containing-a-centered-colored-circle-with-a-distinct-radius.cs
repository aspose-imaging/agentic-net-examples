using System;
using System.IO;
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
            // Output directory for generated BMP files
            string outputDir = @"C:\temp\circles";
            Directory.CreateDirectory(outputDir);

            // Define radii and colors for each image
            int[] radii = new int[] { 50, 100, 150 };
            Aspose.Imaging.Color[] colors = new Aspose.Imaging.Color[]
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue
            };

            for (int i = 0; i < radii.Length; i++)
            {
                int radius = radii[i];
                Aspose.Imaging.Color fillColor = colors[i % colors.Length];

                // Image size includes a margin around the circle
                int canvasSize = radius * 2 + 20;
                string outputPath = Path.Combine(outputDir, $"circle_{radius}.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create file source and BMP options
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions bmpOptions = new BmpOptions
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                // Create a BMP canvas bound to the file source
                using (Image canvas = Image.Create(bmpOptions, canvasSize, canvasSize))
                {
                    // Draw on the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    // Calculate bounds for the centered circle
                    int left = (canvasSize - radius * 2) / 2;
                    int top = (canvasSize - radius * 2) / 2;
                    Rectangle circleBounds = new Rectangle(left, top, radius * 2, radius * 2);

                    // Fill the circle with the specified color
                    using (SolidBrush brush = new SolidBrush(fillColor))
                    {
                        graphics.FillEllipse(brush, circleBounds);
                    }

                    // Save the bound image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}