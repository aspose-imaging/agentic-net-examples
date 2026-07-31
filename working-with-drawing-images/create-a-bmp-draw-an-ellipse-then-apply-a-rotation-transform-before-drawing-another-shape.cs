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
            // Output file path
            string outputPath = "Output\\ellipse_rotated.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a file source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.Wheat);

                // Draw an ellipse
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawEllipse(blackPen, new Rectangle(100, 100, 300, 200));

                // Apply a rotation transform (45 degrees)
                graphics.RotateTransform(45);

                // Draw a rectangle after rotation
                Pen redPen = new Pen(Color.Red, 2);
                graphics.DrawRectangle(redPen, new Rectangle(150, 150, 200, 100));

                // Save the image (file is already bound to the source)
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
 * 1. When a developer needs to generate a BMP report thumbnail that highlights an elliptical region and a rotated rectangle for a medical imaging annotation tool.
 * 2. When creating a custom watermark image in BMP format where an ellipse represents a logo and a rotated rectangle adds a decorative border for branding.
 * 3. When building a game asset pipeline that programmatically draws shapes—such as an ellipse for a character’s hitbox and a rotated rectangle for a directional indicator—directly into a BMP sprite sheet.
 * 4. When automating the production of printable diagrams in C# where an ellipse outlines a process step and a rotated rectangle shows a rotated component orientation in engineering documentation.
 * 5. When developing a UI mockup generator that outputs BMP mock screens with geometric placeholders, using an ellipse for a profile picture area and a rotated rectangle for a tilted button preview.
 */