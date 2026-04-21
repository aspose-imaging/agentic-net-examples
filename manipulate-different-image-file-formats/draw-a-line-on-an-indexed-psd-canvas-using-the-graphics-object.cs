using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path for the indexed PSD file
            string outputPath = Path.Combine("output", "indexed_canvas.psd");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure PSD options for an indexed color mode with a simple palette
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            // Create a new PSD image (e.g., 400x400 pixels)
            using (Image image = Image.Create(psdOptions, 400, 400))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line from (50,50) to (350,350)
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(350, 350));

                // Save the changes to the bound file
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}