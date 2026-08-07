using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Wrap the whole logic in a try-catch to handle unexpected errors gracefully
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\bigimage.tif";

            string outputPathTopLeft     = @"C:\Images\quadrant_0.png";
            string outputPathTopRight    = @"C:\Images\quadrant_1.png";
            string outputPathBottomLeft  = @"C:\Images\quadrant_2.png";
            string outputPathBottomRight = @"C:\Images\quadrant_3.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image using Aspose.Imaging.Image.Load (the standard load rule)
            using (Image image = Image.Load(inputPath))
            {
                // Determine half dimensions for quadrant calculation
                int halfWidth  = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define the four quadrant rectangles
                var rectTopLeft     = new Rectangle(0, 0, halfWidth, halfHeight);
                var rectTopRight    = new Rectangle(halfWidth, 0, halfWidth, halfHeight);
                var rectBottomLeft  = new Rectangle(0, halfHeight, halfWidth, halfHeight);
                var rectBottomRight = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight);

                // Prepare PNG save options (default options are sufficient)
                var pngOptions = new PngOptions();

                // Ensure output directories exist before each save
                Directory.CreateDirectory(Path.GetDirectoryName(outputPathTopLeft) ?? ".");
                image.Save(outputPathTopLeft, pngOptions, rectTopLeft);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathTopRight) ?? ".");
                image.Save(outputPathTopRight, pngOptions, rectTopRight);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathBottomLeft) ?? ".");
                image.Save(outputPathBottomLeft, pngOptions, rectBottomLeft);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPathBottomRight) ?? ".");
                image.Save(outputPathBottomRight, pngOptions, rectBottomRight);
            }
        }
        catch (Exception ex)
        {
            // Output any runtime exception message without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a GIS analyst needs to break a massive BigTIFF satellite image into four smaller PNG tiles for faster web map rendering.
 * 2. When a medical imaging system must extract the four quadrants of a high‑resolution pathology slide stored as a BigTIFF and save them as PNGs for separate diagnostic review.
 * 3. When a digital archivist wants to split a large scanned manuscript saved in BigTIFF format into equal quadrants to create manageable PNG previews for online browsing.
 * 4. When a game developer has a huge texture atlas in BigTIFF format and needs to divide it into four PNG quadrants to feed into the engine’s asset pipeline.
 * 5. When an e‑commerce platform processes large product photographs stored as BigTIFF and needs to generate four PNG sections for targeted zoom‑in sections on the product page.
 */