using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\star.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define image size
        int width = 500;
        int height = 500;

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics
            Graphics graphics = new Graphics(image);

            // Clear background
            graphics.Clear(Color.White);

            // Star parameters
            int centerX = width / 2;
            int centerY = height / 2;
            int outerRadius = 200;
            int innerRadius = 80;
            int pointsCount = 5;

            // Calculate star vertices
            Point[] starPoints = new Point[pointsCount * 2];
            double angleStep = Math.PI / pointsCount;
            for (int i = 0; i < pointsCount * 2; i++)
            {
                double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                double angle = i * angleStep - Math.PI / 2; // start at top
                int x = centerX + (int)(radius * Math.Cos(angle));
                int y = centerY + (int)(radius * Math.Sin(angle));
                starPoints[i] = new Point(x, y);
            }

            // Draw the star using a pen
            Pen starPen = new Pen(Color.Gold, 3);
            graphics.DrawPolygon(starPen, starPoints);

            // Save the image (file is already bound to outputPath)
            image.Save();
        }
    }
}