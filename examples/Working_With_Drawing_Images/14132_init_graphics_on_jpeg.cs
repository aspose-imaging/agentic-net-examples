using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Define the directory containing the JPEG image.
        string dir = @"c:\temp\";

        // Load an existing JPEG image from a file.
        using (JpegImage jpegImage = new JpegImage(dir + "input.jpg"))
        {
            // Initialize a Graphics object for the loaded JPEG image.
            Graphics graphics = new Graphics(jpegImage);

            // Example drawing: fill the entire image with a solid red color.
            SolidBrush redBrush = new SolidBrush(Color.Red);
            graphics.FillRectangle(redBrush, jpegImage.Bounds);

            // Save the modified image to a new JPEG file.
            jpegImage.Save(dir + "output.jpg");
        }
    }
}