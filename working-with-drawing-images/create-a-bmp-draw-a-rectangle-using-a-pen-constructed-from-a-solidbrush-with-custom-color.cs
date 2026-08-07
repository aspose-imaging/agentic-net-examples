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
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BMP options with a FileCreateSource
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Create a SolidBrush with a custom color
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 128, 0, 128))) // Purple
                {
                    // Construct a Pen from the SolidBrush
                    Pen pen = new Pen(brush);

                    // Draw a rectangle using the Pen
                    graphics.DrawRectangle(pen, new Rectangle(100, 100, 300, 200));
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail that highlights a specific area with a purple rectangle for a reporting dashboard.
 * 2. When an automated document‑generation system must embed a custom‑colored rectangle into a BMP placeholder image to indicate a selected region in a C# application.
 * 3. When a Windows desktop utility creates a printable BMP map and uses a SolidBrush‑based Pen to draw a colored bounding box around a user‑defined zone.
 * 4. When a batch image‑processing script programmatically adds a visual marker to BMP files before archiving them, using Aspose.Imaging’s Graphics, Pen, and SolidBrush classes.
 * 5. When a testing framework needs to produce a known BMP file with a precise rectangle shape and color to validate image‑comparison algorithms in .NET.
 */