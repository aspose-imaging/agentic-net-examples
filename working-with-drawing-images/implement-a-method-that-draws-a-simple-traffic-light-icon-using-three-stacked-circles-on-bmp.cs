using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = "output\\traffic_light.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image dimensions
            int width = 200;
            int height = 500;

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to black
                graphics.Clear(Aspose.Imaging.Color.Black);

                // Draw the traffic light housing (white outline)
                Pen housingPen = new Pen(Aspose.Imaging.Color.White, 3);
                graphics.DrawRectangle(housingPen, new Rectangle(50, 50, 100, 400));

                // Draw red light
                using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    graphics.FillEllipse(redBrush, new Rectangle(75, 80, 50, 50));
                }

                // Draw yellow light
                using (SolidBrush yellowBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
                {
                    graphics.FillEllipse(yellowBrush, new Rectangle(75, 190, 50, 50));
                }

                // Draw green light
                using (SolidBrush greenBrush = new SolidBrush(Aspose.Imaging.Color.Green))
                {
                    graphics.FillEllipse(greenBrush, new Rectangle(75, 300, 50, 50));
                }

                // Save the image to the specified path
                image.Save(outputPath, bmpOptions);
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
 * 1. When a developer needs to generate a BMP traffic‑light icon with stacked red, yellow, and green circles for a Windows desktop application UI using C# and Aspose.Imaging.
 * 2. When a developer wants to create a simple traffic signal illustration in a black‑background BMP file for documentation, tutorials, or training materials.
 * 3. When a developer must programmatically draw a white‑outlined housing and colored circles to simulate a traffic control panel in an image processing demo.
 * 4. When a developer requires a quick method to render stacked colored ellipses in a BMP image for testing color detection or image analysis algorithms.
 * 5. When a developer needs to embed a lightweight traffic‑light graphic into a report or PDF by first saving it as a BMP using Aspose.Imaging’s Graphics and Brush classes.
 */