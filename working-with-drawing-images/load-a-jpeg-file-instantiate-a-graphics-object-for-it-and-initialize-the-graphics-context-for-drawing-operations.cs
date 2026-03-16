using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.jpg";
        string outputPath = "output.jpg";

        using (JpegImage jpegImage = new JpegImage(inputPath))
        {
            // Create a Graphics instance for the loaded JPEG image
            Graphics graphics = new Graphics(jpegImage);

            // Initialize the graphics context (e.g., clear with a white background)
            graphics.Clear(Color.White);

            // Additional drawing operations can be performed here

            // Save the modified image
            jpegImage.Save(outputPath);
        }
    }
}