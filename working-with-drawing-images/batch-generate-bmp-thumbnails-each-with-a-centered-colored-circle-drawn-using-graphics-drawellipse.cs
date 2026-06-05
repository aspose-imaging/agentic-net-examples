using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "InputImages";
        string outputDirectory = "Thumbnails";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in inputFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_thumb.bmp");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load source image
                using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
                {
                    // Define thumbnail size
                    int thumbWidth = 100;
                    int thumbHeight = 100;

                    // Resize source image to thumbnail dimensions
                    srcImage.Resize(thumbWidth, thumbHeight);

                    // Create BMP options bound to the output file
                    BmpOptions bmpOptions = new BmpOptions();
                    bmpOptions.BitsPerPixel = 24;
                    bmpOptions.Source = new FileCreateSource(outputPath, false);

                    // Create the thumbnail canvas
                    using (Image thumbImage = Image.Create(bmpOptions, thumbWidth, thumbHeight))
                    {
                        // Initialize graphics for drawing
                        Graphics graphics = new Graphics(thumbImage);
                        graphics.Clear(Color.White);

                        // Draw the resized source image onto the canvas
                        graphics.DrawImage(srcImage, new Point(0, 0));

                        // Draw a centered colored circle
                        int radius = 30;
                        int centerX = thumbWidth / 2;
                        int centerY = thumbHeight / 2;
                        Pen pen = new Pen(Color.Red, 3);
                        graphics.DrawEllipse(pen, new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2));

                        // Save the thumbnail (output path already bound)
                        thumbImage.Save();
                    }
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
 * 1. When a developer needs to create a gallery of small BMP preview images for a desktop application and highlight each thumbnail with a centered colored circle to indicate selection status.
 * 2. When an e‑learning platform stores scanned worksheets as BMP files and wants to display quick preview icons that include a colored circular marker for each document.
 * 3. When a medical imaging system archives BMP scans and requires lightweight thumbnails with a colored circle to denote the primary image in a series.
 * 4. When a game developer prepares BMP sprite sheets and needs uniform 100 px thumbnails with a colored circle to mark the anchor point for each sprite.
 * 5. When a document management solution must index large BMP scans and provide searchable thumbnail previews that include a colored circle to flag confidential files.
 */