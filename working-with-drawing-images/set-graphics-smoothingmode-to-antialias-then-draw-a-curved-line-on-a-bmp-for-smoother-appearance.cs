using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a BMP image (400x200)
            BmpOptions bmpOptions = new BmpOptions();
            using (Image image = Image.Create(bmpOptions, 400, 200))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Apply anti-aliasing for smoother curves
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Define points for the curved line
                Point[] points = new Point[]
                {
                    new Point(50, 150),
                    new Point(150, 50),
                    new Point(250, 150),
                    new Point(350, 50)
                };

                // Draw the curve with a blue pen of width 3
                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawCurve(pen, points);

                // Save the BMP image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}