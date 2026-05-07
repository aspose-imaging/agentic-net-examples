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
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create source bound to the output file
            Source fileSource = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = fileSource };

            // Create a 200x200 BMP canvas bound to the file
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 200, 200))
            {
                // Clear the canvas to red
                Graphics graphics = new Graphics(canvas);
                graphics.Clear(Color.Red);

                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}