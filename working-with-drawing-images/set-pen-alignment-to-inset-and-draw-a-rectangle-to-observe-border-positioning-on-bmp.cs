using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Create a pen with inset alignment
                Pen pen = new Pen(Color.Black, 10);
                pen.Alignment = PenAlignment.Inset;

                // Draw a rectangle to observe border positioning
                graphics.DrawRectangle(pen, 0, 0, 200, 200);

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}