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
            // Output file path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a file source bound to the output path
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 500;
            int height = 500;

            // Create BMP canvas
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear background to navy
                graphics.Clear(Color.Navy);

                // Create a white pen
                Pen whitePen = new Pen(Color.White, 1);

                // Draw diagonal lines forming a cross
                graphics.DrawLine(whitePen, new Point(0, 0), new Point(width, height));
                graphics.DrawLine(whitePen, new Point(0, height), new Point(width, 0));

                // Save the image (output is already bound to the source)
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
 * 1. When generating a simple placeholder image for a legacy Windows application that only supports BMP files, a developer can use this code to create a navy‑background icon with a white diagonal cross to indicate a missing or disabled resource.
 * 2. When building an automated test suite that validates image‑processing pipelines, a developer can programmatically produce a 500×500 BMP with a known pattern (navy background and white X) to compare against expected output.
 * 3. When creating custom watermark graphics for printed reports that must be embedded as BMP files, a developer can use this code to draw a high‑contrast white X on a navy canvas to mark confidential pages.
 * 4. When developing a game that uses BMP sprites for retro‑style graphics, a developer can generate a navy‑colored tile with a white diagonal cross to represent a “blocked” or “impassable” terrain tile.
 * 5. When implementing a batch job that prepares thumbnail previews for a collection of scanned documents, a developer can quickly generate a BMP placeholder with a navy background and white X to flag files that failed to load.
 */