using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas dimensions
        int width = 500;
        int height = 500;

        // Create the BMP image bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize Graphics for drawing on the image
            Graphics graphics = new Graphics(image);

            // Create a thick pen (e.g., 10 pixels wide) with a chosen color
            Pen pen = new Pen(Color.Blue, 10);

            // Draw a rectangle border around the entire canvas
            graphics.DrawRectangle(pen, new Rectangle(0, 0, width, height));

            // Save the image (since it's bound to a FileCreateSource, just call Save)
            image.Save();
        }
    }
}