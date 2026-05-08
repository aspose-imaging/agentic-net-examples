using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions
            {
                // Bind the output file
                Source = new FileCreateSource(outputPath, false),

                // Set indexed color mode
                ColorMode = ColorModes.Indexed,

                // Define a simple palette (black and white)
                Palette = new ColorPalette(new Color[] { Color.Black, Color.White })
            };

            int width = 400;
            int height = 300;

            // Create a new PSD image with the specified options
            using (Image image = Image.Create(psdOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a red line from (10,10) to (200,200)
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(10, 10), new Point(200, 200));

                // Save the image (output path already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}