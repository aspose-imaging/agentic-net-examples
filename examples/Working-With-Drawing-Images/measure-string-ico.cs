using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Path to the ICO image
        string icoPath = "input.ico";

        // Load the ICO image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(icoPath))
        {
            // Create a Graphics instance for the loaded image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Define the font to be used for measurement
            Aspose.Imaging.Font font = new Aspose.Imaging.Font("Arial", 24);

            // Define layout area (zero size) and default string format
            Aspose.Imaging.SizeF layoutArea = new Aspose.Imaging.SizeF(0, 0);
            Aspose.Imaging.StringFormat stringFormat = new Aspose.Imaging.StringFormat();

            // Measure the string
            Aspose.Imaging.SizeF measuredSize = graphics.MeasureString("Sample Text", font, layoutArea, stringFormat);

            // Output the measured dimensions
            Console.WriteLine($"Measured Width: {measuredSize.Width}, Measured Height: {measuredSize.Height}");
        }
    }
}