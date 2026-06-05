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
            // Output file path
            string outputPath = "output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create BMP options
            BmpOptions bmpOptions = new BmpOptions();

            // Create a blank image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // First overlapping circle (red, 50% opacity)
                using (SolidBrush brush1 = new SolidBrush(Aspose.Imaging.Color.Red))
                {
                    brush1.Opacity = 0.5f;
                    graphics.FillEllipse(brush1, new Rectangle(50, 50, 200, 200));
                }

                // Second overlapping circle (green, 30% opacity)
                using (SolidBrush brush2 = new SolidBrush(Aspose.Imaging.Color.Green))
                {
                    brush2.Opacity = 0.3f;
                    graphics.FillEllipse(brush2, new Rectangle(150, 100, 200, 200));
                }

                // Third overlapping circle (blue, 70% opacity)
                using (SolidBrush brush3 = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    brush3.Opacity = 0.7f;
                    graphics.FillEllipse(brush3, new Rectangle(250, 50, 200, 200));
                }

                // Save the image
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
 * 1. When a developer needs to create a BMP placeholder image with semi‑transparent overlapping circles to illustrate layering concepts in a C# tutorial using Aspose.Imaging graphics.
 * 2. When a reporting tool must generate a simple bitmap legend where colored circles with different opacity levels indicate confidence intervals for data points.
 * 3. When a game UI designer wants to programmatically produce a BMP texture that shows overlapping colored orbs to test blending modes in a C# game engine using Aspose.Imaging.
 * 4. When an e‑learning platform requires a lightweight BMP diagram that demonstrates how opacity affects the visual depth of overlapping shapes in image processing courses.
 * 5. When an automated testing suite needs to create a deterministic BMP file containing three translucent circles to verify that the Aspose.Imaging rendering pipeline preserves opacity and color blending across formats.
 */