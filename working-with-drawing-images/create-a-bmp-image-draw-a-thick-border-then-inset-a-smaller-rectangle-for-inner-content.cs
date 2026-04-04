using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP creation options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        int width = 500;
        int height = 500;

        // Create BMP image
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear background to white
            graphics.Clear(Color.White);

            // Draw thick outer border
            Pen outerPen = new Pen(Color.Black, 10);
            graphics.DrawRectangle(outerPen, 0, 0, width, height);

            // Draw inner rectangle inset from the border
            int inset = 20;
            Pen innerPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(innerPen, inset, inset, width - 2 * inset, height - 2 * inset);

            // Save the image (output path already bound via FileCreateSource)
            image.Save();
        }
    }
}