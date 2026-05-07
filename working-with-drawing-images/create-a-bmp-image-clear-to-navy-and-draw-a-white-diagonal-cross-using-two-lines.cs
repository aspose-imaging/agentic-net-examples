using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create a source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Define canvas size
            int width = 200;
            int height = 200;

            // Create a BMP canvas bound to the file
            using (BmpImage canvas = (BmpImage)Image.Create(options, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Clear background to navy
                graphics.Clear(Color.Navy);

                // Pen for white lines
                Pen whitePen = new Pen(Color.White, 1);

                // Draw diagonal from top-left to bottom-right
                graphics.DrawLine(whitePen, new Point(0, 0), new Point(width, height));

                // Draw diagonal from bottom-left to top-right
                graphics.DrawLine(whitePen, new Point(0, height), new Point(width, 0));

                // Save the image (bound canvas)
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}