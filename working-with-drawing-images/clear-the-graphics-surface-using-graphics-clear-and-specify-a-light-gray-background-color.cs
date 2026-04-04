using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output path
        string outputPath = "output\\cleared_image.png";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create PNG options with a file create source bound to the output path
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize graphics for the image
            Graphics graphics = new Graphics(image);

            // Clear the surface with light gray color
            graphics.Clear(Aspose.Imaging.Color.LightGray);

            // Save the image (output is already bound via FileCreateSource)
            image.Save();
        }
    }
}