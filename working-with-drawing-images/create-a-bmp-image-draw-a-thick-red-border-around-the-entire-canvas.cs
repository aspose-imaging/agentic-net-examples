// HOW-TO: Create BMP Image With Thick Red Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output BMP file path
            string outputPath = @"C:\temp\border.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a source bound to the output file
            FileCreateSource source = new FileCreateSource(outputPath, false);

            // Set up BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create the BMP canvas
            using (BmpImage canvas = (BmpImage)Aspose.Imaging.Image.Create(options, width, height))
            {
                // Initialize graphics for drawing
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);

                // Create a thick red pen
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 10);

                // Draw the border rectangle
                graphics.DrawRectangle(redPen, 0, 0, canvas.Width, canvas.Height);

                // Save the bound image
                canvas.Save();
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
 * 1. When you need to generate a blank BMP thumbnail and highlight its edges for a UI preview in a Windows desktop application.
 * 2. When you want to programmatically add a colored frame around scanned documents before saving them as BMP files for archival.
 * 3. When creating test images with a visible border to verify image processing pipelines that expect BMP input.
 * 4. When producing BMP assets for a game that require a consistent red outline to indicate selectable objects.
 * 5. When automating the preparation of BMP graphics for printing, adding a thick border to ensure proper cropping marks.
 */
