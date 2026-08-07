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
            // Output file path
            string outputPath = "output\\traffic_light.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP options with a file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = source;
            bmpOptions.BitsPerPixel = 24; // 24‑bpp for true color

            // Canvas dimensions
            int width = 100;
            int height = 300;

            // Create a bound BMP canvas
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Graphics object for drawing
                Graphics graphics = new Graphics(canvas);

                // Fill background with black
                graphics.Clear(Color.Black);

                // Circle size and horizontal offset
                int circleDiameter = 80;
                int offsetX = (width - circleDiameter) / 2;

                // Red circle (top)
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    int offsetYRed = 10;
                    graphics.FillEllipse(redBrush, new Rectangle(offsetX, offsetYRed, circleDiameter, circleDiameter));
                }

                // Yellow circle (middle)
                using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
                {
                    int offsetYYellow = 10 + circleDiameter + 10;
                    graphics.FillEllipse(yellowBrush, new Rectangle(offsetX, offsetYYellow, circleDiameter, circleDiameter));
                }

                // Green circle (bottom)
                using (SolidBrush greenBrush = new SolidBrush(Color.Green))
                {
                    int offsetYGreen = 10 + (circleDiameter + 10) * 2;
                    graphics.FillEllipse(greenBrush, new Rectangle(offsetX, offsetYGreen, circleDiameter, circleDiameter));
                }

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
 * 1. When a developer needs to generate a simple traffic‑light icon as a 24‑bpp BMP file for embedding in a Windows desktop UI, they can use this code to draw three stacked circles with solid brushes.
 * 2. When creating test assets for image‑processing pipelines that require known shapes and colors, this snippet quickly produces a BMP image with red, yellow, and green circles.
 * 3. When building a simulation that visualizes signal states and must export the result to a file‑system‑compatible bitmap, the code demonstrates how to use Aspose.Imaging’s RasterImage and Graphics objects to render the traffic light.
 * 4. When a developer wants to programmatically generate icons for a traffic‑control dashboard and needs to control canvas size, background clearing, and circle positioning using C# and Aspose.Imaging, this example provides the necessary steps.
 * 5. When producing sample BMP files for documentation or unit tests that validate color handling and ellipse drawing in Aspose.Imaging, the code offers a reproducible method to create the traffic‑light image.
 */