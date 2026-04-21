using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Define image dimensions
        int width = 800;
        int height = 600;

        // Define output file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the image and a Graphics object for drawing
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            Graphics graphics = new Graphics(image);
            // Graphics object is ready for drawing operations here

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}