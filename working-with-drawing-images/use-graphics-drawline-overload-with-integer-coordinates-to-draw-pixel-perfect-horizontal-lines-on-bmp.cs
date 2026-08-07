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
            // Hardcoded input/output paths
            string inputPath = @"C:\temp\input.bmp"; // Not used but kept for compliance
            string outputPath = @"C:\temp\output.bmp";

            // Input file existence check (no exception thrown)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 200;
            int height = 100;

            // Create BMP options with a bound output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Pen for drawing horizontal lines (1-pixel wide)
                Pen pen = new Pen(Color.Black, 1);

                // Draw pixel‑perfect horizontal lines across the image
                for (int y = 0; y < height; y++)
                {
                    graphics.DrawLine(pen, 0, y, width - 1, y);
                }

                // Save the image (output is already bound to the file)
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
 * 1. When generating a printable barcode or scanner guide, a developer can use the Graphics.DrawLine overload with integer coordinates to draw pixel‑perfect horizontal lines in a BMP file for precise alignment.
 * 2. When creating a simple grid background for a game UI, the code uses the Graphics.DrawLine overload with integer coordinates to render exact horizontal lines across a BMP canvas that define each row.
 * 3. When visualizing sensor data row‑by‑row, developers employ the Graphics.DrawLine overload with integer coordinates to produce pixel‑perfect horizontal lines in a BMP so each measurement aligns to a single pixel.
 * 4. When preparing a monochrome template for CNC machining or laser cutting, the Graphics.DrawLine overload with integer coordinates draws exact horizontal lines in a BMP that serve as cut paths with no anti‑aliasing.
 * 5. When building a custom chart or timeline image in a .NET application, the Graphics.DrawLine overload with integer coordinates is used to draw crisp horizontal separator lines in a BMP without blurring.
 */