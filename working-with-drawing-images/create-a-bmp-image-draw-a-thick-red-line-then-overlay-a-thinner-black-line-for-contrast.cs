using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream outStream = new FileStream(outputPath, FileMode.Create))
        {
            // Set BMP options with the stream source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(outStream);

            // Create a BMP image of size 200x200
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw a thick red line
                Pen redPen = new Pen(Color.Red, 10);
                graphics.DrawLine(redPen, new Point(20, 20), new Point(180, 180));

                // Overlay a thinner black line for contrast
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawLine(blackPen, new Point(20, 20), new Point(180, 180));

                // Save the image (stream is already bound to the file)
                image.Save();
            }
        }
    }
}