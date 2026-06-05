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
            // Define size specifications (width, height)
            int[][] specs = new int[][]
            {
                new int[] { 200, 200 },
                new int[] { 300, 150 },
                new int[] { 400, 400 }
            };

            for (int i = 0; i < specs.Length; i++)
            {
                int width = specs[i][0];
                int height = specs[i][1];

                // Output path for each BMP
                string outputPath = Path.Combine("output", $"image_{i}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound file source
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.BitsPerPixel = 24;
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create canvas
                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
                {
                    // Calculate centered square dimensions
                    int side = Math.Min(width, height) / 2;
                    int offsetX = (width - side) / 2;
                    int offsetY = (height - side) / 2;

                    // Draw centered square
                    using (SolidBrush brush = new SolidBrush(Color.Blue))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.FillRectangle(brush, new Rectangle(offsetX, offsetY, side, side));
                    }

                    // Save the bound image
                    canvas.Save();
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
 * 1. When a developer needs to generate a set of BMP thumbnails of varying dimensions for a product catalog, using Aspose.Imaging to draw a centered square logo on each canvas.
 * 2. When an automation script must create placeholder BMP images for UI mockups, employing C# and Aspose.Imaging to draw a centered colored square in canvases of different sizes.
 * 3. When a batch image generation tool is required to produce test BMP assets for a game engine, using Aspose.Imaging’s RasterImage and Graphics classes to place a centered square for alignment verification.
 * 4. When a reporting system needs to export chart legends as BMP files, leveraging Aspose.Imaging to draw a centered square marker that scales with each image’s width and height.
 * 5. When a developer wants to pre‑render printable label templates in BMP format, using Aspose.Imaging to draw a centered square watermark that automatically adapts to each label’s dimensions.
 */