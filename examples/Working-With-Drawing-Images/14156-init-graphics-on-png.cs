using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Create a file stream for the PNG image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image with desired dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize the Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Save the image to the specified stream
                image.Save();
            }
        }
    }
}