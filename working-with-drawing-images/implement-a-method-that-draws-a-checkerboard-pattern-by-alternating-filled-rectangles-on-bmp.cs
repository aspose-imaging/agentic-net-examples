using System;
using System.IO;
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
            // Output BMP file path (hard‑coded)
            string outputPath = "output\\checkerboard.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 400;
            int height = 400;
            int rows = 8;
            int cols = 8;
            int cellWidth = width / cols;
            int cellHeight = height / rows;

            // Set up BMP options with a FileCreateSource (binds the file)
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw the checkerboard pattern
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        // Alternate colors
                        Aspose.Imaging.Color cellColor = ((row + col) % 2 == 0) ? Aspose.Imaging.Color.Black : Aspose.Imaging.Color.White;

                        // Create a solid brush for the cell
                        using (SolidBrush brush = new SolidBrush(cellColor))
                        {
                            int x = col * cellWidth;
                            int y = row * cellHeight;
                            graphics.FillRectangle(brush, new Rectangle(x, y, cellWidth, cellHeight));
                        }
                    }
                }

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a BMP file that visualizes a classic 8×8 checkerboard for testing image rendering pipelines in C# using Aspose.Imaging.
 * 2. When creating placeholder graphics for board game UI mock‑ups, a developer can use this code to programmatically draw alternating black and white squares in a BMP image.
 * 3. When validating color depth and file‑creation performance of the Aspose.Imaging Graphics API, a developer can produce a checkerboard pattern to measure rendering speed.
 * 4. When automating the production of printable calibration sheets for scanners, a developer can generate a BMP checkerboard to verify alignment and contrast.
 * 5. When building a unit test that requires a known bitmap with alternating pixel blocks, a developer can employ this code to create a deterministic BMP image for comparison.
 */