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
            // Hardcoded output path
            string outputPath = @"c:\temp\ellipse.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 300x200 image canvas
            using (Image image = Image.Create(bmpOptions, 300, 200))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Create a black pen with width 2
                Pen pen = new Pen(Color.Black, 2);

                // Draw an ellipse inside the full rectangle (0,0,300,200)
                graphics.DrawEllipse(pen, new Rectangle(0, 0, 300, 200));

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
 * 1. When a developer needs to generate a BMP thumbnail that highlights a product’s circular logo inside a fixed‑size 300 × 200 canvas for a legacy Windows application.
 * 2. When an automated reporting tool must embed a black‑outlined ellipse into a BMP chart background to indicate a region of interest in scanned engineering diagrams.
 * 3. When a batch‑processing script creates placeholder images for UI mockups, drawing an ellipse inside a 300 × 200 rectangle to represent a profile picture slot in a BMP asset.
 * 4. When a medical imaging system exports a BMP overlay that marks a region of interest with a black pen ellipse on a white background for compatibility with older DICOM viewers.
 * 5. When a game developer generates BMP sprites at runtime, using Aspose.Imaging to draw an ellipse within a 300 × 200 rectangle as a collision‑boundary visual aid.
 */