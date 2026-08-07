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
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            int width = 200;
            int height = 200;

            RotateFlipType[] rotations = new RotateFlipType[]
            {
                RotateFlipType.Rotate90FlipNone,
                RotateFlipType.Rotate180FlipNone,
                RotateFlipType.Rotate270FlipNone
            };

            foreach (RotateFlipType rot in rotations)
            {
                string outputPath = Path.Combine(outputDir, $"shape_{rot}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source, BitsPerPixel = 24 };

                using (Image canvas = Image.Create(options, width, height))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);
                    Pen pen = new Pen(Color.Blue, 5);
                    graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                    canvas.RotateFlip(rot);
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
 * 1. When a developer needs to generate a series of BMP icons showing a logo rotated at 90°, 180°, and 270° for use in a multi‑orientation desktop application UI.
 * 2. When an automated build process must create rotated versions of a base shape to supply test images for validating image‑processing algorithms that rely on BMP files.
 * 3. When a game asset pipeline requires pre‑rotated sprite sheets in BMP format so that the engine can load them without runtime rotation overhead.
 * 4. When a documentation generator wants to embed step‑by‑step visual guides, producing BMP diagrams of a shape at different angles to illustrate rotation concepts.
 * 5. When a quality‑control tool needs to batch produce BMP samples with consistent dimensions and color depth (24‑bpp) to compare rendering results across different rotation settings.
 */