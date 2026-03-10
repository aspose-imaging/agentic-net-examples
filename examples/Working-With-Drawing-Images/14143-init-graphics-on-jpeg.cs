using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Drawing; // For Rectangle

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"c:\temp\";
        string inputPath = dir + "input.jpg";
        string outputPath = dir + "output.jpg";

        // Load the JPEG image using the JpegImage constructor that accepts a file path
        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Initialize a Graphics object for the loaded JPEG image
            Graphics graphics = new Graphics(jpegImage);

            // Example drawing operation: fill a red rectangle on the image
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Rectangle rect = new Rectangle(10, 10, 100, 50);
            graphics.FillRectangle(redBrush, rect);

            // Save the modified image to a new file
            jpegImage.Save(outputPath);
        }
    }
}