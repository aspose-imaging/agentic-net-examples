using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hard‑coded)
            string outputPath = @"C:\temp\traffic_light.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 24; // 24‑bit color

            // Define canvas size (width x height)
            int canvasWidth = 100;
            int canvasHeight = 300;

            // Create the image canvas bound to the output file
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, canvasWidth, canvasHeight))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Optional: clear background to black
                graphics.Clear(Aspose.Imaging.Color.Black);

                // Circle parameters
                int diameter = 80;
                int centerX = (canvasWidth - diameter) / 2;
                int spacing = 10; // space between circles
                int firstY = spacing;

                // Red light
                using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(redBrush, new Aspose.Imaging.Rectangle(centerX, firstY, diameter, diameter));
                }

                // Yellow light
                using (SolidBrush yellowBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    int y = firstY + diameter + spacing;
                    graphics.FillEllipse(yellowBrush, new Aspose.Imaging.Rectangle(centerX, y, diameter, diameter));
                }

                // Green light
                using (SolidBrush greenBrush = new SolidBrush(Aspose.Imaging.Color.Lime))
                {
                    int y = firstY + 2 * (diameter + spacing);
                    graphics.FillEllipse(greenBrush, new Aspose.Imaging.Rectangle(centerX, y, diameter, diameter));
                }

                // Save the bound image
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
 * 1. When a developer needs to generate a 24‑bit BMP traffic‑light icon for a Windows desktop application’s status indicator, they can use this Aspose.Imaging C# code to draw three stacked circles.
 * 2. When an IoT dashboard requires lightweight bitmap images of traffic signals that can be created on‑the‑fly without external assets, this code provides a programmatic way to render the icon in BMP format.
 * 3. When a game engine needs a simple traffic‑light sprite for a 2‑D simulation and wants to avoid loading PNG files, the example shows how to draw the icon directly into a BMP canvas using Aspose.Imaging graphics.
 * 4. When an automated testing framework must embed a traffic‑light symbol into generated report screenshots, the snippet demonstrates creating the BMP image with solid brushes and ellipse drawing in C#.
 * 5. When a documentation generator wants to include a custom traffic‑light illustration in its PDF output and prefers to create the source BMP programmatically, this code illustrates the necessary steps with Aspose.Imaging.
 */