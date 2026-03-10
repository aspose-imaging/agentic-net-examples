using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Configure BMP options and specify the output file path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource("output.bmp", false);

        // Create a new 500x500 image using the Image.Create rule
        using (Image image = Image.Create(bmpOptions, 500, 500))
        {
            // Initialize a Graphics object for the created image
            Graphics graphics = new Graphics(image);

            // Example operation: clear the surface with a wheat color
            graphics.Clear(Color.Wheat);

            // Save the image using the Image.Save rule
            image.Save();
        }
    }
}