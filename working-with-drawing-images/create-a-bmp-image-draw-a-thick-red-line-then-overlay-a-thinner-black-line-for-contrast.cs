using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\image.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 300;
            int height = 300;

            // Create the image bound to the output file
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Draw a thick red line
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 10);
                graphics.DrawLine(redPen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(250, 250));

                // Overlay a thinner black line for contrast
                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawLine(blackPen, new Aspose.Imaging.Point(50, 50), new Aspose.Imaging.Point(250, 250));

                // Save the image (already bound to the file)
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
 * 1. When a developer needs to programmatically generate a BMP image with a bold red diagonal line and a thin black outline to highlight a path in a Windows desktop utility.
 * 2. When a reporting system must add a thick red marker with a contrasting black edge to a bitmap chart for clearer visual emphasis.
 * 3. When an automated test creates a BMP placeholder that displays a thick red line overlaid by a thin black line to verify UI layout alignment.
 * 4. When a game‑asset pipeline requires a quick BMP texture containing a colored line with a contrasting border for debugging collision detection.
 * 5. When documentation tooling generates a BMP illustration that uses a thick red stroke and a thin black stroke to improve accessibility and readability.
 */