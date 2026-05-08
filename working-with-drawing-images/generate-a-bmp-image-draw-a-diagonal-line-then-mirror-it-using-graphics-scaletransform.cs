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
            // Define output path and ensure its directory exists
            string outputPath = "Output\\output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Define canvas size
            int width = 200;
            int height = 200;

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create a black pen
                Pen pen = new Pen(Color.Black, 2);

                // Draw original diagonal line
                graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

                // Apply horizontal mirroring transform
                graphics.TranslateTransform(width, 0); // Move origin to right edge
                graphics.ScaleTransform(-1, 1);       // Flip horizontally

                // Draw mirrored diagonal line
                graphics.DrawLine(pen, new Point(0, 0), new Point(width, height));

                // Save the image (file is already bound to the source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}