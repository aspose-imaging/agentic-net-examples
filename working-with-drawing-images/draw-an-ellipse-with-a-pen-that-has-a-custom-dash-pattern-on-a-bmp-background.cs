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
            // Output file path
            string outputPath = @"C:\temp\ellipse.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source for the BMP image
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a BMP canvas of desired size
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Fill background with a solid color
                graphics.Clear(Color.LightGray);

                // Create a pen with custom dash pattern
                Pen pen = new Pen(Color.Blue, 5);
                pen.DashPattern = new float[] { 5, 2 };

                // Draw an ellipse using the custom pen
                graphics.DrawEllipse(pen, new Rectangle(50, 50, 200, 150));

                // Save the image (bound to the file source)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}