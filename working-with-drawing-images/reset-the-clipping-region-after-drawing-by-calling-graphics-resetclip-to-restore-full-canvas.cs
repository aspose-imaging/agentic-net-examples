using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load source image to obtain dimensions
            using (Image src = Image.Load(inputPath))
            {
                int width = src.Width;
                int height = src.Height;

                // Create a new PNG image with the same size
                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);
                using (Image outImg = Image.Create(pngOptions, width, height))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(outImg);

                    // Set a clipping region (inner rectangle)
                    graphics.Clip = new Region(new Rectangle(50, 50, width - 100, height - 100));

                    // Draw a red rectangle (will be clipped)
                    graphics.DrawRectangle(new Pen(Color.Red, 5), new Rectangle(0, 0, width, height));

                    // Reset the clipping region to restore full canvas
                    graphics.Clip = null;

                    // Draw a green rectangle (covers full canvas)
                    graphics.DrawRectangle(new Pen(Color.Green, 5), new Rectangle(0, 0, width, height));

                    // Save the resulting image
                    outImg.Save();
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
 * 1. When generating a PNG thumbnail and need to draw a red border only inside a safe area, then reset the clipping region to add a full‑canvas green overlay later.
 * 2. When applying a clipped mask to highlight a specific region of an image and then want to place a watermark that covers the entire picture, resetting the clip with Graphics.ResetClip is required.
 * 3. When creating a composite PNG where a decorative frame is drawn inside an inner rectangle and a background color must be painted across the whole image, you must clear the clipping region after the frame is rendered.
 * 4. When processing scanned documents and you want to outline a region of interest with a red rectangle while still being able to draw annotations on the rest of the page, resetting the clipping region restores full drawing capability.
 * 5. When building a UI mock‑up that first restricts drawing to a content pane and later adds a full‑page grid or guide lines, you need to call Graphics.ResetClip to remove the previous clipping region.
 */