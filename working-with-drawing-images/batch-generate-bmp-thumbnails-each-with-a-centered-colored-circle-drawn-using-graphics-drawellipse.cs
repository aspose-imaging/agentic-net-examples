using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded list of input image files
            string[] inputFiles = { "input1.jpg", "input2.png", "input3.tif" };
            // Output directory for thumbnails
            string outputDir = "Thumbnails";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            foreach (var inputPath in inputFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Define thumbnail size
                    int thumbWidth = 100;
                    int thumbHeight = 100;

                    // Resize image to thumbnail dimensions
                    image.Resize(thumbWidth, thumbHeight);

                    // Create Graphics object for drawing
                    Graphics graphics = new Graphics(image);

                    // Calculate centered circle dimensions
                    int diameter = Math.Min(image.Width, image.Height) / 2;
                    int x = (image.Width - diameter) / 2;
                    int y = (image.Height - diameter) / 2;
                    Rectangle circleRect = new Rectangle(x, y, diameter, diameter);

                    // Define pen for the circle outline
                    Pen pen = new Pen(Color.Red, 3);

                    // Draw the centered ellipse (circle)
                    graphics.DrawEllipse(pen, circleRect);

                    // Prepare output file path
                    string outputPath = Path.Combine(outputDir,
                        Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp");

                    // Ensure the output directory exists (redundant but follows safety rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the thumbnail as BMP
                    image.Save(outputPath, new BmpOptions());
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
 * 1. When a web application needs to create 100 × 100 pixel BMP thumbnails of user‑uploaded photos and overlay a red circular badge to indicate featured images.
 * 2. When an e‑commerce platform wants to generate small BMP preview icons for product pictures and highlight each with a centered colored circle for quick visual categorization.
 * 3. When a desktop utility processes a batch of mixed‑format images (JPG, PNG, TIFF) to produce uniform BMP thumbnails with a red outline circle for use in a custom file explorer.
 * 4. When a reporting tool automatically creates BMP thumbnail charts from source images and draws a centered ellipse to mark the region of interest before embedding them in PDF reports.
 * 5. When a digital asset management system needs to resize various image formats to BMP thumbnails and add a centered colored circle as a watermark to indicate copyright status.
 */