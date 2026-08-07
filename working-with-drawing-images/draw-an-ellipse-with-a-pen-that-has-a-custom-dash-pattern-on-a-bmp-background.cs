using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input path (example, not used for drawing)
            string inputPath = @"C:\temp\input.bmp";

            // Hardcoded output path
            string outputPath = @"C:\temp\output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP creation options
            BmpOptions bmpOptions = new BmpOptions
            {
                // Create the file at the specified output path
                Source = new FileCreateSource(outputPath, false),
                BitsPerPixel = 24 // 24‑bit true color
            };

            // Create a new 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Fill background with a wheat color
                graphics.Clear(Color.Wheat);

                // Create a pen with custom dash pattern
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 5f, 2f, 1f, 2f };

                // Draw an ellipse inside the specified rectangle
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

                // Save the image to the output file
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
 * 1. When a developer needs to generate a 24‑bit BMP report graphic with a wheat‑colored background and a custom‑dashed ellipse for a printable dashboard.
 * 2. When an application must programmatically create a placeholder image for a UI component, using Aspose.Imaging for .NET to draw an ellipse with a Pen that has a custom dash pattern on a BMP canvas.
 * 3. When a server‑side service creates thumbnail maps where the region of interest is highlighted by a dashed ellipse drawn on a BMP file using C# graphics primitives.
 * 4. When a developer wants to embed a stylized ellipse annotation into a BMP asset for a medical imaging workflow, leveraging Aspose.Imaging’s Pen.DashPattern to convey measurement intervals.
 * 5. When an automated testing tool needs to produce a BMP image with a specific background color and a custom‑dashed ellipse to verify rendering consistency across different devices.
 */