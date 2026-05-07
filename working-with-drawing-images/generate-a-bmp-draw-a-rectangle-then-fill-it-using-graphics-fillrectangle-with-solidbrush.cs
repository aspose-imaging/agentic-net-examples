using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";   // Not used in this example but kept for rule compliance
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Input file existence check (rule compliance)
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (rule compliance)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions and settings
            int width = 200;
            int height = 200;

            // Configure BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Optional: clear background to white
                graphics.Clear(Color.White);

                // Draw a black rectangle border
                Pen blackPen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(blackPen, 10, 10, width - 20, height - 20);

                // Fill a rectangle inside the border with a solid brush
                SolidBrush fillBrush = new SolidBrush(Color.LightBlue);
                graphics.FillRectangle(fillBrush, new Rectangle(20, 20, width - 40, height - 40));

                // Save the image (the FileCreateSource already points to outputPath)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}