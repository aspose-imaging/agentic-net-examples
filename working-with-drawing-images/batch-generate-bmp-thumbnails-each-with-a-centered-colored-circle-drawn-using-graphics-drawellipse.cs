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
            // Input and output directories (hardcoded)
            string inputDir = "InputImages";
            string outputDir = "Thumbnails";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                // Verify each input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp");

                // Ensure output directory for the file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load source image (not used for content, only to trigger processing)
                using (Image srcImage = Image.Load(inputPath))
                {
                    // Define thumbnail size
                    int thumbWidth = 100;
                    int thumbHeight = 100;

                    // Create a blank BMP image for the thumbnail
                    BmpOptions bmpOptions = new BmpOptions();
                    using (Image thumbImage = Image.Create(bmpOptions, thumbWidth, thumbHeight))
                    {
                        // Initialize graphics for drawing
                        Graphics graphics = new Graphics(thumbImage);
                        graphics.Clear(Color.White);

                        // Calculate centered circle parameters
                        int radius = Math.Min(thumbWidth, thumbHeight) / 2 - 5; // 5px margin
                        int centerX = thumbWidth / 2;
                        int centerY = thumbHeight / 2;
                        int left = centerX - radius;
                        int top = centerY - radius;
                        int diameter = radius * 2;

                        // Draw the circle
                        graphics.DrawEllipse(new Pen(Color.Red, 3), new Rectangle(left, top, diameter, diameter));

                        // Save the thumbnail as BMP
                        thumbImage.Save(outputPath, new BmpOptions());
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