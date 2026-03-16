using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    static void Main(string[] args)
    {
        // Path to the ICO image file
        string icoPath = "input.ico";

        // Text to measure
        string text = "Sample Text";

        // Load the ICO image as a raster image
        using (RasterImage icoImage = (RasterImage)Image.Load(icoPath))
        {
            // Create a Graphics instance for the image
            Graphics graphics = new Graphics(icoImage);

            // Define the font to use for measurement
            Font font = new Font("Arial", 24);

            // Define the layout area (full image size)
            SizeF layoutArea = new SizeF(icoImage.Width, icoImage.Height);

            // Use default string format
            StringFormat format = new StringFormat();

            // Measure the string
            SizeF measuredSize = graphics.MeasureString(text, font, layoutArea, format);

            // Output the measured dimensions
            Console.WriteLine($"Measured size: Width = {measuredSize.Width}, Height = {measuredSize.Height}");
        }
    }
}