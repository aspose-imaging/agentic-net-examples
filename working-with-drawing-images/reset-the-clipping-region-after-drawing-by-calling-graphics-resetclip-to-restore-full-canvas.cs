using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.png";
            string outputPath = @"C:\temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Create Graphics for drawing (no using block)
                Graphics graphics = new Graphics(image);

                // Set a clipping region
                graphics.Clip = new Region(new Rectangle(50, 50, 200, 200));

                // Draw a red filled rectangle (affected by clipping)
                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(redBrush, new Rectangle(0, 0, image.Width, image.Height));
                }

                // Reset clipping to full canvas
                graphics.Clip = null;

                // Draw a blue filled rectangle (covers entire image)
                using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
                {
                    graphics.FillRectangle(blueBrush, new Rectangle(0, 0, image.Width, image.Height));
                }

                // Save the modified image to the output path
                image.Save(outputPath);
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
 * 1. When generating a product catalog thumbnail in PNG format and need to apply a watermark only inside a specific area before filling the rest of the image with a background color, you would set a clipping region, draw the watermark, then call Graphics.ResetClip to restore the full canvas for the background fill.
 * 2. When creating a dynamic badge image where a logo must be drawn inside a circular mask and the surrounding area should be painted with a solid color, you would use graphics.Clip to limit the logo rendering and then reset the clip to paint the outer ring.
 * 3. When processing scanned documents and need to redact a confidential rectangle while keeping the rest of the page unchanged, you would clip to the redaction area, fill it with black, then reset the clip before adding a page‑number footer across the whole page.
 * 4. When building a game UI overlay in C# that first draws a semi‑transparent health bar inside a defined panel and later draws a full‑screen vignette effect, resetting the clipping region after the health bar ensures the vignette covers the entire screen.
 * 5. When automating batch image conversion and want to apply a color filter only to the central portion of each JPEG before applying a global watermark, you would set a rectangular clip, apply the filter, call Graphics.ResetClip, and then draw the watermark over the whole image.
 */