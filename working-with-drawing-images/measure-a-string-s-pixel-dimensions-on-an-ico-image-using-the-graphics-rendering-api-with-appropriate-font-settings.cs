using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input ICO file path
        string inputPath = @"C:\temp\input.ico";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Create a Graphics instance for the loaded image
            Graphics graphics = new Graphics(image);

            // Define the font to be used for measurement
            Font font = new Font("Arial", 24, FontStyle.Regular);

            // Define the layout area (use the whole image)
            SizeF layoutArea = new SizeF(image.Width, image.Height);

            // Use default string formatting
            StringFormat format = new StringFormat();

            // Text to measure
            string text = "Sample Text";

            // Measure the string's pixel dimensions
            SizeF measuredSize = graphics.MeasureString(text, font, layoutArea, format);

            // Output the measured width and height
            Console.WriteLine($"Measured size: Width = {measuredSize.Width}, Height = {measuredSize.Height}");
        }
    }
}