using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path for the BMP logo
            string outputPath = @"C:\Temp\custom_logo.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x400 BMP image
            using (Image image = Image.Create(bmpOptions, 400, 400))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Clear background to white
                graphics.Clear(Color.White);

                // Draw outer rectangle (logo border)
                graphics.DrawRectangle(new Pen(Color.Black, 4), new Rectangle(10, 10, 380, 380));

                // Draw a filled blue rectangle
                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(blueBrush, new Rectangle(50, 50, 120, 80));
                }

                // Draw a red ellipse inside the blue rectangle
                graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(70, 60, 80, 60));

                // Draw a green filled ellipse at the bottom right
                using (SolidBrush greenBrush = new SolidBrush(Color.Green))
                {
                    graphics.FillEllipse(greenBrush, new Rectangle(250, 250, 100, 100));
                }

                // Draw a yellow rectangle overlapping the green ellipse
                graphics.DrawRectangle(new Pen(Color.Yellow, 2), new Rectangle(260, 260, 80, 80));

                // Save the image (file is already bound via FileCreateSource)
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
 * 1. When a developer needs to generate a simple corporate badge or watermark as a BMP file by programmatically drawing rectangles and ellipses with Aspose.Imaging in C#.
 * 2. When an application must create device‑specific splash screens or boot logos for embedded systems that only support 24‑bit BMP images.
 * 3. When a reporting tool has to embed a custom logo composed of geometric shapes into exported BMP charts without relying on external image assets.
 * 4. When a game engine requires dynamically generated BMP textures for UI elements such as buttons or icons that are built from rectangles and ellipses at runtime.
 * 5. When an automated testing framework needs to produce placeholder BMP images with identifiable shapes to verify image‑processing pipelines using Aspose.Imaging’s Graphics API.
 */