using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"C:\temp\polygon.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                // CreateSource points to the file that will be created
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image of size 400x400
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background with white color
                graphics.Clear(Color.White);

                // Create a pen with custom line join style
                Pen pen = new Pen(Color.Blue, 5);
                pen.LineJoin = LineJoin.Bevel; // Custom line join (Bevel)

                // Define polygon vertices
                Point[] points = new Point[]
                {
                    new Point(50, 300),
                    new Point(200, 50),
                    new Point(350, 300)
                };

                // Draw the connected polygon
                graphics.DrawPolygon(pen, points);

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