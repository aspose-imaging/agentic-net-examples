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
            // Output file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a FileStream as the source for BmpOptions
            using (FileStream stream = new FileStream(outputPath, FileMode.Create))
            {
                // Configure BmpOptions with the stream source
                BmpOptions bmpOptions = new BmpOptions() { Source = new StreamSource(stream) };

                // Create a 400x400 BMP canvas bound to the stream
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 400, 400))
                {
                    // Fill the canvas with yellow
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.Yellow);

                    // Save the bound image
                    canvas.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}