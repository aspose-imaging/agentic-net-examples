using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Define output file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Create a source bound to the output file
        Source source = new FileCreateSource(outputPath, false);

        // Set BMP options with the source
        BmpOptions options = new BmpOptions() { Source = source };

        // Create a 200x200 BMP canvas bound to the file
        using (RasterImage canvas = (RasterImage)Image.Create(options, 200, 200))
        {
            // Obtain a Graphics object for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear the canvas with red color
            graphics.Clear(Color.Red);

            // Save the bound image to the specified file
            canvas.Save();
        }
    }
}