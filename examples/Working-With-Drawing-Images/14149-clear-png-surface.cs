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
        // Output file path
        string outputPath = "cleared_image.png";

        // Create PNG options and set the source to a file stream
        PngOptions pngOptions = new PngOptions();
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            pngOptions.Source = new StreamSource(stream);

            // Create a new PNG image with desired dimensions
            using (Image image = Image.Create(pngOptions, 800, 600))
            {
                // Obtain a Graphics object for the image
                Graphics graphics = new Graphics(image);

                // Clear the entire surface with white color
                graphics.Clear(Color.White);

                // Save changes (the stream is already bound to the image)
                image.Save();
            }
        }
    }
}