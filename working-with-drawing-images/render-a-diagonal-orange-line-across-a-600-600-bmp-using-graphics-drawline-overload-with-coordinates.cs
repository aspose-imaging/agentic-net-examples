using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "output\\diagonal.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 600x600 image
        using (Image image = Image.Create(bmpOptions, 600, 600))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Draw an orange diagonal line from top-left to bottom-right
            Pen pen = new Pen(Color.Orange, 2);
            graphics.DrawLine(pen, 0, 0, 600, 600);

            // Save the image (file is already bound to the source)
            image.Save();
        }
    }
}