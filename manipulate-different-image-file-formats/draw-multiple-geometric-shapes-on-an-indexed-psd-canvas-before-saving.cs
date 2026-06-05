using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output PSD file path
            string outputPath = @"C:\temp\output.psd";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Configure PSD options for an indexed image
            PsdOptions psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = ColorModes.Indexed;
            psdOptions.CompressionMethod = CompressionMethod.RLE;
            psdOptions.ChannelBitsCount = 8;   // 8 bits per channel
            psdOptions.ChannelsCount = 1;      // Indexed uses a single channel

            // Build a simple 256‑color palette (first few entries are defined, rest are transparent)
            Color[] baseColors = new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                Color.Magenta,
                Color.Cyan
            };
            Color[] fullPalette = new Color[256];
            for (int i = 0; i < fullPalette.Length; i++)
            {
                fullPalette[i] = i < baseColors.Length ? baseColors[i] : Color.Transparent;
            }
            psdOptions.Palette = new ColorPalette(fullPalette);

            // Create the indexed PSD canvas (output file is already bound)
            using (Image image = Image.Create(psdOptions, 500, 500))
            {
                // Initialize graphics (do NOT wrap in using)
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.White);

                // Draw a black line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(50, 50), new Point(450, 50));

                // Draw and fill a red rectangle
                graphics.DrawRectangle(new Pen(Color.Red, 2), new Rectangle(100, 100, 300, 200));
                using (SolidBrush rectBrush = new SolidBrush(Color.Cyan))
                {
                    graphics.FillRectangle(rectBrush, new Rectangle(110, 110, 280, 180));
                }

                // Draw and fill a green ellipse
                graphics.DrawEllipse(new Pen(Color.Green, 2), new Rectangle(150, 250, 200, 100));
                using (SolidBrush ellipseBrush = new SolidBrush(Color.Yellow))
                {
                    graphics.FillEllipse(ellipseBrush, new Rectangle(160, 260, 180, 80));
                }

                // Draw and fill a purple polygon
                Point[] polygonPoints = new Point[]
                {
                    new Point(250, 150),
                    new Point(300, 200),
                    new Point(200, 200)
                };
                graphics.DrawPolygon(new Pen(Color.Purple, 2), polygonPoints);
                using (SolidBrush polyBrush = new SolidBrush(Color.Orange))
                {
                    graphics.FillPolygon(polyBrush, polygonPoints);
                }

                // Save the image (output file is already bound)
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
 * 1. When a developer needs to generate a lightweight PSD thumbnail with basic vector shapes for a web‑based asset preview, they can use this code to draw shapes on an indexed 8‑bit canvas and save it as a compressed PSD file.
 * 2. When creating a batch of printable color‑separated plates where only a limited palette is allowed, this example lets the developer draw geometric guides on an indexed PSD and export it with RLE compression.
 * 3. When building a game level editor that stores background maps as PSD files with a fixed 256‑color palette, the code provides a quick way to render walls, platforms, and obstacles as shapes on the indexed canvas.
 * 4. When automating the production of corporate brand guidelines that require simple shape diagrams embedded in PSD mockups with a predefined palette, developers can use this snippet to draw the diagrams and save them in the required format.
 * 5. When developing a scientific reporting tool that overlays measurement markers on scanned images and needs to keep file size low by using an indexed PSD, this code enables drawing those markers as geometric shapes before saving.
 */