// HOW-TO: Draw Red Line on Indexed PSD Canvas Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Psd;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = @"output\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PSD options for an indexed image
            PsdOptions options = new PsdOptions();
            options.Source = new FileCreateSource(outputPath, false);
            options.ColorMode = ColorModes.Indexed;
            // Simple palette with two colors (required for indexed mode)
            options.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });

            // Create the PSD canvas
            using (Image image = Image.Create(options, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a red line
                graphics.DrawLine(new Pen(Color.Red, 5), new Point(50, 50), new Point(450, 450));

                // Save the image (source is already bound to the file)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a PSD file with a limited color palette and add simple vector graphics such as a colored line programmatically in C#.
 * 2. When you are building a web service that creates indexed‑color Photoshop files for thumbnails and must draw annotation lines on the image.
 * 3. When you have to export design mock‑ups from a .NET application to PSD format while preserving a two‑color palette for compatibility with older Photoshop versions.
 * 4. When you want to automate the creation of printable guides inside a PSD by drawing precise lines on an indexed canvas without using Photoshop manually.
 * 5. When you are testing image‑processing pipelines and require a reproducible PSD containing a known line shape to validate downstream filters.
 */
