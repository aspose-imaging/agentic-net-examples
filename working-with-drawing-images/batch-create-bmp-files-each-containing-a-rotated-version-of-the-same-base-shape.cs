using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            int width = 200;
            int height = 200;

            // Define the rotations/flips to apply
            RotateFlipType[] rotateTypes = new RotateFlipType[]
            {
                RotateFlipType.Rotate90FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate270FlipNone,
                RotateFlipType.RotateNoneFlipX,
                RotateFlipType.RotateNoneFlipY
            };

            foreach (var rotate in rotateTypes)
            {
                // Output file path
                string outputPath = Path.Combine(outputDir, $"shape_{rotate}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound output file
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create image canvas
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    // Draw a simple rectangle shape
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Blue, 5);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                    // Apply rotation/flip
                    image.RotateFlip(rotate);

                    // Save the bound image
                    image.Save();
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
 * 1. When generating a set of sprite assets for a 2D game that requires the same shape in multiple orientations, a developer can use this code to batch‑create BMP files with rotated rectangles.
 * 2. When preparing test images for a computer‑vision algorithm that must recognize objects regardless of rotation, a developer can quickly produce BMP samples with different RotateFlip types.
 * 3. When creating printable labels or icons that need to be displayed in portrait and landscape layouts, a developer can automate the production of rotated BMP files.
 * 4. When building a batch‑processing pipeline that converts vector shapes to raster BMP thumbnails for a catalog, a developer can use this code to generate each thumbnail in several orientations.
 * 5. When developing a UI theme that includes mirrored or flipped graphics for right‑to‑left languages, a developer can generate the required BMP assets by applying RotateFlip operations in bulk.
 */