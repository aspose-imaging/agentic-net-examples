using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a 200x200 BMP image
            using (Image image = Image.Create(bmpOptions, 200, 200))
            {
                // Graphics for drawing
                Graphics graphics = new Graphics(image);

                // Thick red line
                Pen thickRedPen = new Pen(Color.Red, 10);
                graphics.DrawLine(thickRedPen, new Point(20, 20), new Point(180, 180));

                // Thinner black line for contrast
                Pen thinBlackPen = new Pen(Color.Black, 2);
                graphics.DrawLine(thinBlackPen, new Point(20, 20), new Point(180, 180));

                // Save the image
                image.Save(outputPath, bmpOptions);
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
 * 1. When generating a BMP icon for a desktop application that requires a bold red line with a thin black outline to improve visibility across different UI themes.
 * 2. When creating a printable schematic in C# where a thick red line highlights a critical path and a thinner black line adds contrast for laser engraving.
 * 3. When producing a diagnostic BMP image for a medical device that uses a thick red marker overlaid with a thin black line to emphasize a region of interest.
 * 4. When building a game asset pipeline that programmatically draws highlighted borders on BMP textures, using a thick red stroke with a finer black edge for depth.
 * 5. When automating the generation of custom watermarks in BMP format where a bold red line is overlaid with a thinner black line to ensure legibility on both light and dark backgrounds.
 */