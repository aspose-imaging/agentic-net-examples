using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory for generated BMP files
            string outputDir = @"C:\temp\BmpBatch";
            Directory.CreateDirectory(outputDir);

            // Define colors for diagonal lines
            List<Aspose.Imaging.Color> colors = new List<Aspose.Imaging.Color>
            {
                Aspose.Imaging.Color.Red,
                Aspose.Imaging.Color.Green,
                Aspose.Imaging.Color.Blue,
                Aspose.Imaging.Color.Yellow,
                Aspose.Imaging.Color.Purple
            };

            // Corresponding color names for file naming
            List<string> colorNames = new List<string> { "Red", "Green", "Blue", "Yellow", "Purple" };

            int width = 200;
            int height = 200;

            for (int i = 0; i < colors.Count; i++)
            {
                // Build output file path
                string outputPath = Path.Combine(outputDir, $"diag_{colorNames[i]}.bmp");

                // Ensure the directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up BMP creation options
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create a new image canvas
                using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
                {
                    // Initialize graphics for drawing
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                    // Create a pen with the current color
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(colors[i], 5);

                    // Draw a diagonal line from top-left to bottom-right
                    graphics.DrawLine(pen, new Aspose.Imaging.Point(0, 0), new Aspose.Imaging.Point(width, height));

                    // Save the image (output path is already bound via FileCreateSource)
                    image.Save();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}