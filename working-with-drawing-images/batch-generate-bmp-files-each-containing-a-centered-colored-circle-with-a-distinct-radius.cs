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
        // Output directory for generated BMP files
        string outputDir = @"C:\temp\circles";

        // Define radii and corresponding colors for each image
        int[] radii = { 50, 100, 150 };
        Color[] colors = { Color.Red, Color.Green, Color.Blue };

        for (int i = 0; i < radii.Length; i++)
        {
            // Construct output file path
            string outputPath = Path.Combine(outputDir, $"circle_{i + 1}.bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare BMP options with file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 24; // 24‑bpp color

            // Determine canvas size (radius * 2 + margin)
            int canvasSize = radii[i] * 2 + 20;

            // Create the BMP image canvas
            using (Image image = Image.Create(bmpOptions, canvasSize, canvasSize))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Calculate bounds for the centered circle
                int radius = radii[i];
                int centerX = canvasSize / 2;
                int centerY = canvasSize / 2;
                Rectangle bounds = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

                // Fill the circle with the specified color
                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    graphics.FillEllipse(brush, bounds);
                }

                // Since the image is bound to a file source, save directly
                image.Save();
            }
        }
    }
}