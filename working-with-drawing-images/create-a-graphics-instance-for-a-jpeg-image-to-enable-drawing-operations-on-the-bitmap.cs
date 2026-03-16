using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Configure JPEG creation options and bind the output file
        JpegOptions jpegOptions = new JpegOptions();
        jpegOptions.Source = new FileCreateSource(outputPath, false);

        // Define image dimensions
        int width = 500;
        int height = 500;

        // Create a new JPEG image bound to the specified file
        using (Image image = Image.Create(jpegOptions, width, height))
        {
            // Initialize Graphics for drawing on the JPEG image
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Example drawing: a blue rectangle
            Pen pen = new Pen(Color.Blue, 5);
            graphics.DrawRectangle(pen, new Rectangle(50, 50, 200, 150));

            // Save the image (no parameters needed because the source is already bound)
            image.Save();
        }
    }
}