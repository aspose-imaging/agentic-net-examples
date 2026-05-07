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
            string outputPath = @"C:\Temp\ellipse.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source for the PNG image
            Source source = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions() { Source = source };

            // Create a new 800x600 PNG canvas
            using (Image image = Image.Create(options, 800, 600))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw a red ellipse
                graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(100, 100, 600, 400));

                // Save the image (bound to the file source)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}