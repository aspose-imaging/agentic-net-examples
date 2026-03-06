using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output PNG file path
        string outputPath = "output.png";

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Initialize PNG options and bind the stream as the source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a blank PNG image with the specified dimensions
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a wheat color
                graphics.Clear(Color.Wheat);

                // Save changes to the bound stream
                image.Save();
            }
        }
    }
}