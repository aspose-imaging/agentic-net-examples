using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output\\image.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP image options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a BMP image canvas
            using (Image image = Image.Create(bmpOptions, 200, 100))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 50), new Point(100, 50));

                // Scale X axis by 2 to double subsequent drawing lengths
                graphics.ScaleTransform(2.0f, 1.0f);

                // Draw a red line (will appear twice as long due to scaling)
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(10, 70), new Point(100, 70));

                // Save the image to the specified path
                image.Save(outputPath, bmpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}