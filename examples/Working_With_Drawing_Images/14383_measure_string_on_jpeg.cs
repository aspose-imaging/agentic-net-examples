using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Path to the JPEG image
        string inputPath = "input.jpg";

        // Text to measure
        string text = "Sample text for measurement";

        // Load the JPEG image
        using (JpegImage jpeg = new JpegImage(inputPath))
        {
            // Create a Graphics instance for the image
            Graphics graphics = new Graphics(jpeg);

            // Define the font to be used for measurement
            Font font = new Font("Arial", 24);

            // Measure the string size (no layout constraints, no special formatting)
            SizeF size = graphics.MeasureString(text, font, new SizeF(0, 0), null);

            // Output the measured dimensions
            Console.WriteLine($"Measured size: Width = {size.Width}, Height = {size.Height}");
        }
    }
}