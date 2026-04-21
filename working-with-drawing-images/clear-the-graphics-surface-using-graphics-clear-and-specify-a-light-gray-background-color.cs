using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path
        string outputPath = @"C:\temp\output.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a file stream for the output image
        using (FileStream stream = new FileStream(outputPath, FileMode.Create))
        {
            // Set up PNG options with the stream as source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new StreamSource(stream);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(pngOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with a light gray background
                graphics.Clear(Color.LightGray);

                // Save the image (stream is already bound)
                image.Save();
            }
        }
    }
}