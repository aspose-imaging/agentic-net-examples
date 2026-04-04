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
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the BMP image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set BMP options with the stream as source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new StreamSource(stream);

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a thick red line
                graphics.DrawLine(new Pen(Color.Red, 10), new Point(10, 10), new Point(190, 190));

                // Overlay a thinner black line for contrast
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 10), new Point(190, 190));

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}