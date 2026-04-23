using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up PNG options with a FileCreateSource (binds the image to the file)
        var pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image canvas (500x500)
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 500, 500))
        {
            // Initialize Graphics from the created image
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Enable anti-aliasing for smoother edges
            graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

            // Optional: clear the canvas with a white background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Save the image (already bound to the output file)
            image.Save();
        }
    }
}