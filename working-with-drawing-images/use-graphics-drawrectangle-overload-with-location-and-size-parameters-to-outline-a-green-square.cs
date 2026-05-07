using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        const string outputPath = @"c:\temp\green_square.png";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            var pngOptions = new Aspose.Imaging.ImageOptions.PngOptions();
            pngOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);

            // Create a 200x200 image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(pngOptions, 200, 200))
            {
                // Initialize graphics for the image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a green pen with a thickness of 2
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Green, 2);

                // Draw a green square at (50,50) with size 100x100
                graphics.DrawRectangle(pen, 50, 50, 100, 100);

                // Save the image (source is already bound to the output file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}