using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

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

            // Load the vector image
            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                // Prepare PNG options with bound output file
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                // Create a raster canvas
                using (Image canvas = Image.Create(pngOptions, width, height))
                {
                    // Draw the vector image onto the canvas
                    Graphics graphics = new Graphics(canvas);
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    // Apply color overlay (semi‑transparent red, RGBA 128,255,0,0)
                    using (SolidBrush overlayBrush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                    {
                        graphics.FillRectangle(overlayBrush, canvas.Bounds);
                    }

                    // Save the final PNG
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