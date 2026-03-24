using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\source.png";
        string outputPath = @"C:\temp\output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source image (RasterImage) to be drawn onto the canvas
        using (RasterImage sourceImage = (RasterImage)Image.Load(inputPath))
        {
            // Define image creation options with a memory buffer limit (e.g., 30 MB)
            PngOptions createOptions = new PngOptions
            {
                BufferSizeHint = 30,
                Source = new FileCreateSource(outputPath, false)
            };

            const int canvasWidth = 2000;
            const int canvasHeight = 2000;

            // Create a new image canvas bound to the output file
            using (Image canvas = Image.Create(createOptions, canvasWidth, canvasHeight))
            {
                // Initialize Graphics for drawing
                Graphics graphics = new Graphics(canvas);

                // Begin update to cache drawing operations (memory‑efficient)
                graphics.BeginUpdate();

                // Clear background
                graphics.Clear(Color.LightGray);

                // Draw the loaded source image onto the canvas
                graphics.DrawImage(sourceImage,
                    new Rectangle(100, 100, sourceImage.Width, sourceImage.Height),
                    new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
                    GraphicsUnit.Pixel);

                // Perform a large number of line drawing operations
                const int step = 20;
                for (int x = 0; x < canvasWidth; x += step)
                {
                    graphics.DrawLine(new Pen(Color.Blue, 1), x, 0, x, canvasHeight);
                }
                for (int y = 0; y < canvasHeight; y += step)
                {
                    graphics.DrawLine(new Pen(Color.Red, 1), 0, y, canvasWidth, y);
                }

                // End update to apply all cached operations at once
                graphics.EndUpdate();

                // Save the image (output path already bound via FileCreateSource)
                canvas.Save();
            }
        }
    }
}