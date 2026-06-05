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
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // BMP image options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 400;
            int height = 300;

            // Create the BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Draw a thick black border around the image
                Pen borderPen = new Pen(Color.Black, 10);
                graphics.DrawRectangle(borderPen, 0, 0, width, height);

                // Fill an inner rectangle inset from the border
                using (SolidBrush innerBrush = new SolidBrush(Color.LightGray))
                {
                    int inset = 20;
                    graphics.FillRectangle(innerBrush, inset, inset, width - 2 * inset, height - 2 * inset);
                }

                // Save the image (file is already bound to outputPath)
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
 * 1. When a developer needs to programmatically create a BMP image with a thick black border and a light‑gray inset rectangle for use as a printable report header or footer.
 * 2. When an application must generate placeholder graphics for UI mockups, such as a bordered canvas that visually separates content sections in a Windows Forms prototype.
 * 3. When a batch process creates standardized image assets for a document management system, ensuring each BMP file has a consistent border thickness and inner background color.
 * 4. When a game or simulation engine requires a simple texture with a defined outer frame and inner area to serve as a UI panel or dialog background.
 * 5. When an automated testing tool needs to produce a known‑size BMP file with a clear border and inner fill to verify image rendering and file‑output functionality in .NET applications.
 */