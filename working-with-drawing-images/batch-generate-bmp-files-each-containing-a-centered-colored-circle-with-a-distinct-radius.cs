using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory for BMP files
            string outputDir = @"C:\temp\circles";
            Directory.CreateDirectory(outputDir);

            // Canvas size (must accommodate the largest circle)
            int canvasWidth = 200;
            int canvasHeight = 200;

            // Define radii and corresponding colors for each BMP
            var circles = new List<(int radius, Color color)>
            {
                (30, Color.Red),
                (40, Color.Green),
                (50, Color.Blue)
            };

            int index = 1;
            foreach (var (radius, color) in circles)
            {
                string outputPath = Path.Combine(outputDir, $"circle_{index}.bmp");
                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create source and BMP options
                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions
                {
                    Source = source,
                    BitsPerPixel = 24
                };

                // Create a bound BMP image
                using (Image image = Image.Create(options, canvasWidth, canvasHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(image);

                    // Calculate rectangle to center the circle
                    int x = (canvasWidth - radius * 2) / 2;
                    int y = (canvasHeight - radius * 2) / 2;
                    Rectangle rect = new Rectangle(x, y, radius * 2, radius * 2);

                    // Fill the centered circle with the specified color
                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        graphics.FillEllipse(brush, rect);
                    }

                    // Save the bound image
                    image.Save();
                }

                index++;
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
 * 1. When a developer needs to generate a set of BMP icons with centered colored circles of varying radii for a UI theme or button set.
 * 2. When an automation script must create placeholder images for testing image‑processing pipelines that expect 24‑bit BMP files with specific dimensions.
 * 3. When a reporting tool requires dynamically generated chart markers saved as BMP files to embed in PDF or Word documents.
 * 4. When a game developer wants to pre‑render simple circular sprites in different colors and sizes to reduce runtime drawing overhead.
 * 5. When a data‑visualization service needs to batch‑produce thumbnail images showing colored circles to represent categorical data in dashboards.
 */