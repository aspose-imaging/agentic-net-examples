using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Create a PNG image with a file stream as the source
        using (FileStream stream = new FileStream("output.png", FileMode.Create))
        {
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create the image canvas (500x500 pixels)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize a Graphics object for drawing on the image
                Graphics graphics = new Graphics(image);

                // Optional: clear the canvas with a background color
                graphics.Clear(Color.Wheat);

                // Save the image with the applied graphics operations
                image.Save();
            }
        }
    }
}