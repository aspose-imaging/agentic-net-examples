using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP creation options
        BmpOptions bmpOptions = new BmpOptions
        {
            // Set the file where the image will be created
            Source = new FileCreateSource(outputPath, false),
            // Use 24 bits per pixel (standard truecolor)
            BitsPerPixel = 24
        };

        // Create a 1024x768 BMP image
        using (Image image = Image.Create(bmpOptions, 1024, 768))
        {
            // Optional: fill the image with a solid color (white)
            Graphics graphics = new Graphics(image);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            graphics.FillRectangle(whiteBrush, image.Bounds);

            // Save the image to the specified path
            image.Save();
        }
    }
}