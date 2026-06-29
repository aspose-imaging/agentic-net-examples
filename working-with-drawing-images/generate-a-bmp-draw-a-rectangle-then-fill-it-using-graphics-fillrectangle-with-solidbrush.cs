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
        // Hardcoded output path
        string outputPath = @"c:\temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 500x500 image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Fill a rectangle with a solid brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(brush, new Rectangle(100, 100, 300, 200));
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
 * 1. When a developer needs to programmatically generate a BMP file in C# and draw a solid‑colored rectangle for a simple diagram or placeholder image.
 * 2. When an application must create a 500×500 bitmap thumbnail and fill a region with a specific color using Aspose.Imaging’s Graphics.FillRectangle and SolidBrush.
 * 3. When a reporting tool requires embedding a blue rectangle into a white background BMP to highlight a section of a generated chart.
 * 4. When a Windows service automates the production of custom‑size BMP assets for UI skins, needing to clear the canvas and fill a rectangle with a solid brush.
 * 5. When a batch process creates printable BMP graphics for signage, using Aspose.Imaging to set BitsPerPixel, clear the image, and fill a rectangle with a chosen color.
 */