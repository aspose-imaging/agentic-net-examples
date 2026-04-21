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
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas dimensions
        int width = 500;
        int height = 400;

        // Create the image; it is already bound to the output file
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Optional: clear the canvas with a white background
            graphics.Clear(Color.White);

            // Create a thick pen (e.g., 5 pixels wide) for the bold rectangle border
            Pen thickPen = new Pen(Color.Black, 5f);

            // Draw the rectangle border around the entire canvas
            graphics.DrawRectangle(thickPen, 0, 0, width, height);

            // Save the image (writes to the bound output file)
            image.Save();
        }
    }
}