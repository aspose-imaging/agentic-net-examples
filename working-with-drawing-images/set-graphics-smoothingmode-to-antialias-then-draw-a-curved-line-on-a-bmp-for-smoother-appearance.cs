using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file create source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Enable antialiasing for smoother curves
                graphics.SmoothingMode = Aspose.Imaging.SmoothingMode.AntiAlias;

                // Optional: clear background to white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a pen for drawing the curve
                Pen pen = new Pen(Aspose.Imaging.Color.Blue, 3);

                // Draw a smooth curved line
                graphics.DrawCurve(pen, new[]
                {
                    new Point(50, 250),
                    new Point(150, 50),
                    new Point(250, 250),
                    new Point(350, 50),
                    new Point(450, 250)
                });

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

/*
 * Real-World Use Cases:
 * 1. When generating a printable BMP diagram of a road map where smooth curved routes are required for visual clarity.
 * 2. When creating a BMP signature stamp with a flowing handwritten curve that must appear anti‑aliased for professional quality.
 * 3. When producing a BMP thumbnail for a UI that includes curved progress bars, and the developer wants the curves to look smooth on low‑resolution displays.
 * 4. When exporting a scientific BMP chart that plots a spline curve of data points, and anti‑aliasing is needed to avoid jagged lines.
 * 5. When building a BMP asset for a game’s 2‑D background that contains decorative wavy lines, and the code ensures the curves render without pixelated edges.
 */