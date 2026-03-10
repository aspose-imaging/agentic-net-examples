using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output image path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with a stream source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image canvas (400x200)
            using (Image image = Image.Create(pngOptions, 400, 200))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Define the font to be measured
                Font font = new Font("Arial", 24);

                // Define layout area for measurement
                SizeF layoutArea = new SizeF(400, 200);

                // Use default string format
                StringFormat stringFormat = new StringFormat();

                // Measure the string
                SizeF measuredSize = graphics.MeasureString("Hello Aspose!", font, layoutArea, stringFormat);

                // Output measured dimensions
                Console.WriteLine($"Measured Width: {measuredSize.Width}, Height: {measuredSize.Height}");

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}