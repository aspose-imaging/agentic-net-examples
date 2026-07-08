using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = @"C:\temp\bordered_image.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 800;
            int height = 600;

            // Create BMP canvas bound to the file
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Create graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Define a thick red pen
                Pen redPen = new Pen(Color.Red, 10);

                // Draw rectangle border around the entire canvas
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
 * 1. When a developer needs to generate a BMP thumbnail with a visible red frame for a legacy Windows application that only accepts BMP files.
 * 2. When an automated report generator must add a thick red border to each exported BMP chart to highlight it in printed documentation.
 * 3. When a batch image processing tool creates placeholder BMP images with a colored outline to indicate missing content in a media asset pipeline.
 * 4. When a game asset pipeline requires BMP textures with a red margin to be recognized by an older engine that uses border color for collision detection.
 * 5. When a document conversion service adds a red rectangular border around BMP pages to comply with branding guidelines before merging them into a PDF.
 */