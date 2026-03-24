using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\output.png";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Set up PNG options with a FileCreateSource bound to the output file
        PngOptions pngOptions = new PngOptions();
        pngOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new image (500x500) and obtain a Graphics instance bound to it
        using (Image image = Image.Create(pngOptions, 500, 500))
        {
            Graphics graphics = new Graphics(image);

            // Clear the canvas with a wheat color
            graphics.Clear(Color.Wheat);

            // Draw a simple black line
            graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 450));

            // Save changes (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}