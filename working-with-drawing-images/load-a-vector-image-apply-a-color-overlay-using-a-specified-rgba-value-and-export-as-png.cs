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
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (SVG)
            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                // Create a PNG canvas
                PngOptions pngOptions = new PngOptions();
                using (Image pngImage = Image.Create(pngOptions, width, height))
                {
                    // Draw the vector image onto the PNG canvas
                    Graphics graphics = new Graphics(pngImage);
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    // Define overlay color (RGBA)
                    int overlayR = 255;
                    int overlayG = 0;
                    int overlayB = 0;
                    int overlayA = 128; // 0-255

                    Color overlayColor = Color.FromArgb(overlayA, overlayR, overlayG, overlayB);

                    // Apply color overlay
                    using (SolidBrush overlayBrush = new SolidBrush())
                    {
                        overlayBrush.Color = overlayColor;
                        overlayBrush.Opacity = (int)(overlayA * 100.0 / 255.0); // convert to percentage
                        graphics.FillRectangle(overlayBrush, new Rectangle(0, 0, width, height));
                    }

                    // Save the result as PNG
                    pngImage.Save(outputPath, pngOptions);
                }
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
 * 1. When a developer needs to generate a branded thumbnail by overlaying a semi‑transparent corporate color onto an SVG logo and saving it as a PNG for web use.
 * 2. When an e‑commerce platform wants to apply a promotional red tint to product vector illustrations before exporting them as PNGs for email campaigns.
 * 3. When a mobile app creates custom map markers by loading SVG icons, adding a user‑selected RGBA highlight, and rendering them as PNG assets.
 * 4. When a reporting tool converts SVG charts into PNG images with a colored overlay to indicate status levels such as warning or error.
 * 5. When a UI designer automates the production of theme‑aware icons by applying a theme color overlay to SVG files and exporting the results as PNG files for Windows applications.
 */