// HOW-TO: Create a Traffic Light BMP Image with Three Circles in C# (Aspose.Imaging for .NET)
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
            // Output path for the traffic light BMP image
            string outputPath = "output/traffic_light.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a file source bound to the output path
            FileCreateSource source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions options = new BmpOptions() { Source = source };

            // Create a BMP canvas (width: 100, height: 300) for three stacked circles
            using (Image image = Image.Create(options, 100, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw red circle (top)
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillEllipse(redBrush, new Rectangle(25, 10, 50, 50));
                }

                // Draw yellow circle (middle)
                using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillEllipse(yellowBrush, new Rectangle(25, 110, 50, 50));
                }

                // Draw green circle (bottom)
                using (SolidBrush greenBrush = new SolidBrush(Color.Green))
                {
                    graphics.FillEllipse(greenBrush, new Rectangle(25, 210, 50, 50));
                }

                // Save the bound image
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
 * 1. When you need to generate a simple traffic‑light icon for a UI dashboard without using external graphics files.
 * 2. When you want to programmatically create a BMP file that can be embedded in legacy Windows applications that only support BMP.
 * 3. When you need to produce a quick visual representation of signal states (red, yellow, green) for testing or documentation purposes.
 * 4. When you are building a simulation or game that requires dynamically drawn traffic‑light symbols at runtime.
 * 5. When you must generate a small, low‑resolution image for printing on labels or reports where BMP format is required.
 */
