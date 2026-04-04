using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define output path (hardcoded)
        string outputPath = @"c:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics for the created image
            Graphics graphics = new Graphics(image);

            // Set smoothing mode to AntiAlias for smoother edges
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // (Optional) Clear the canvas with a background color
            graphics.Clear(Color.White);

            // Save the image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}