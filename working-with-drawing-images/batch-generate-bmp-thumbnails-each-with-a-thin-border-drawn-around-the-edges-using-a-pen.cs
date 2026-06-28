using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
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
            Directory.CreateDirectory(outputDir);

            // Process each BMP file in the input directory
            foreach (string inputPath in Directory.GetFiles(inputDir, "*.bmp"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, resize, draw border, and save
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 100x100 thumbnail
                    image.Resize(100, 100);

                    // Draw a thin black border around the image
                    Graphics graphics = new Graphics(image);
                    graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, image.Width - 1, image.Height - 1);

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
 * 1. When a developer needs to create a gallery of small preview images for legacy Windows applications that only support BMP files, they can batch‑process source BMPs into 100 × 100 thumbnails with a thin black border for consistent UI layout.
 * 2. When an automated build pipeline must generate low‑resolution BMP assets for embedded devices with limited color depth, this code can resize each source image and add a border to clearly delineate the thumbnail area.
 * 3. When a content‑management system imports user‑uploaded BMP scans and requires uniform thumbnail previews with a visible frame, the batch script provides a quick way to produce 100 px thumbnails with a 1‑pixel border.
 * 4. When a developer is preparing documentation screenshots in BMP format and wants all images to have the same size and a subtle border for visual separation, the code can process an entire folder in one run.
 * 5. When a game engine that only reads BMP textures needs preview icons for its asset browser, this routine can generate 100 × 100 thumbnail BMPs with a thin border to improve recognizability without altering the original files.
 */