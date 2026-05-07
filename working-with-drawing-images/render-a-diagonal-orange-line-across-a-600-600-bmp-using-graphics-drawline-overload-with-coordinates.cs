using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Set up BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 600x600 BMP image canvas
            using (Image image = Image.Create(bmpOptions, 600, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create an orange pen
                Pen pen = new Pen(Color.Orange, 1);

                // Draw a diagonal line from top-left to bottom-right
                graphics.DrawLine(pen, 0, 0, 599, 599);

                // Save the image (output path is already bound)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}