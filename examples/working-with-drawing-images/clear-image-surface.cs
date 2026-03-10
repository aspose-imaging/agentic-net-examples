using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output file path
        string outputPath = "output.png";

        // Configure PNG options and bind them to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image with the specified dimensions
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics for drawing on the image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the entire surface with the chosen color
            graphics.Clear(Aspose.Imaging.Color.Wheat);

            // Save the changes to the bound file
            image.Save();
        }
    }
}