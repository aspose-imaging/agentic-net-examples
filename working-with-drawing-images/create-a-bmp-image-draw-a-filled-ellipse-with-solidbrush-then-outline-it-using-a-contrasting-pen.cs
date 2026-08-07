using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\ellipse.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a BMP image of size 400x300
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Optional: clear background
                graphics.Clear(Aspose.Imaging.Color.White);

                // Define a solid brush for filling the ellipse
                SolidBrush fillBrush = new SolidBrush(Aspose.Imaging.Color.LightBlue);

                // Define the bounding rectangle for the ellipse
                Rectangle ellipseRect = new Rectangle(50, 50, 300, 200);

                // Fill the ellipse
                graphics.FillEllipse(fillBrush, ellipseRect);

                // Define a pen for outlining the ellipse (contrasting color)
                Pen outlinePen = new Pen(Aspose.Imaging.Color.DarkBlue, 3);

                // Draw the ellipse outline
                graphics.DrawEllipse(outlinePen, ellipseRect);

                // Save changes to the file
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
 * 1. Use this code to generate a 24‑bit BMP placeholder image with a light‑blue filled ellipse outlined in dark blue for UI mockups in a C# desktop application.
 * 2. Use the BMP image creation and Graphics.FillEllipse/DrawEllipse methods to add a colored ellipse marker to a chart or report generated in .NET.
 * 3. Create a custom button background BMP where the ellipse indicates a selected state, leveraging SolidBrush and Pen for fill and outline in C#.
 * 4. Automate thumbnail icon generation for a document management system by drawing a blue ellipse overlay on a 400×300 BMP using Aspose.Imaging.
 * 5. Export a simple diagram element as a BMP file for a CAD or engineering tool, using the rectangle bounds to control ellipse size and a contrasting pen for the outline.
 */