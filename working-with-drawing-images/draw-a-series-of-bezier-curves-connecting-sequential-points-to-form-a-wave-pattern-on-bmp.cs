using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = "output_wave.bmp";

        // Ensure the output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

        // Image dimensions
        int width = 1200;
        int height = 300;

        // Create BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Define points for the wave pattern (multiple Bezier segments)
            Point[] wavePoints = new Point[]
            {
                new Point(0,   150),
                new Point(100,  50),
                new Point(200, 250),
                new Point(300, 150),

                new Point(400,  50),
                new Point(500, 250),
                new Point(600, 150),

                new Point(700,  50),
                new Point(800, 250),
                new Point(900, 150),

                new Point(1000, 50),
                new Point(1100,250),
                new Point(1200,150)
            };

            // Pen for drawing the Bezier curves
            Pen pen = new Pen(Color.Blue, 2);

            // Draw the series of Bezier curves forming a wave
            graphics.DrawBeziers(pen, wavePoints);

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}