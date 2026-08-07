using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path (relative)
            string outputPath = "Output/output.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define image size
            int width = 200;
            int height = 200;

            // Create a new PNG image
            using (PngImage png = new PngImage(width, height))
            {
                // Optional: fill the image with a solid color
                Graphics graphics = new Graphics(png);
                SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red);
                graphics.FillRectangle(brush, png.Bounds);

                // Store original dimensions
                int originalWidth = png.Width;
                int originalHeight = png.Height;

                // Rotate 45 degrees without resizing, using transparent background
                png.Rotate(45f, false, Aspose.Imaging.Color.Transparent);

                // Verify that dimensions remain unchanged
                bool dimensionsUnchanged = (png.Width == originalWidth) && (png.Height == originalHeight);
                Console.WriteLine(dimensionsUnchanged
                    ? "Dimensions unchanged after rotation."
                    : $"Dimensions changed: {originalWidth}x{originalHeight} -> {png.Width}x{png.Height}");

                // Save the rotated image
                png.Save(outputPath);
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
 * 1. When generating product thumbnails for an e‑commerce site, a developer can create a 200 × 200 PNG, rotate it 45° with a transparent background, and confirm the canvas size stays the same to maintain layout consistency.
 * 2. When preparing assets for a mobile game UI, a developer may need to rotate icon images by 45 degrees without resizing the PNG so that hit‑testing and sprite sheets remain aligned.
 * 3. When automating the creation of watermark overlays, a developer can produce a PNG, apply a 45‑degree rotation with transparency, and verify unchanged dimensions to ensure the watermark fits the original document size.
 * 4. When converting scanned documents to PNG for archival, a developer might rotate each page 45 degrees to correct skew while preserving the original width and height for downstream processing.
 * 5. When building a reporting tool that embeds rotated charts into PDF reports, a developer can generate a PNG, rotate it 45° with a transparent background, and check that the image dimensions are unchanged to avoid layout shifts in the final PDF.
 */