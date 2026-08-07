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
            // Hardcoded input and output directories
            string inputDir = "Input";
            string outputDir = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add BMP files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Process each BMP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.bmp"))
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to thumbnail size (e.g., 100x100)
                    image.Resize(100, 100, ResizeType.NearestNeighbourResample);

                    // Draw a thin black border around the image
                    Graphics graphics = new Graphics(image);
                    Pen pen = new Pen(Color.Black, 1);
                    graphics.DrawRectangle(pen, 0, 0, image.Width - 1, image.Height - 1);

                    // Save as BMP
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
 * 1. When a developer needs to create a gallery of small preview images for a legacy Windows application that only supports BMP files, they can batch‑process source BMPs into 100 × 100 thumbnails with a thin black border for consistent UI layout.
 * 2. When an automated build pipeline must generate printable contact‑sheet thumbnails of scanned documents stored as BMPs, this code can resize each page and add a border to clearly separate individual images.
 * 3. When a content‑management system requires fast, low‑overhead preview icons for user‑uploaded BMP assets, the snippet can run on a server to produce bordered thumbnails that improve visual selection.
 * 4. When a developer is preparing BMP assets for a game’s level‑editor that displays a grid of icons, the batch routine creates uniformly sized thumbnails with a visible frame to help designers spot missing or corrupted files.
 * 5. When a digital‑forensics tool needs to display a quick visual summary of many BMP evidence files, the program can generate bordered thumbnails that make it easy to browse and compare images side by side.
 */