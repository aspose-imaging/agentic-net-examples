using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\ellipse.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new image (size large enough to contain the rectangle)
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Define the bounding rectangle (300 × 200)
                Rectangle rect = new Rectangle(50, 50, 300, 200);

                // Draw the ellipse with a black pen (width 2)
                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawEllipse(pen, rect);

                // Save the image (writes to the path specified in bmpOptions)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}