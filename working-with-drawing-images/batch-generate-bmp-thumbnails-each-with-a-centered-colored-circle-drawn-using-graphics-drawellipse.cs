// HOW-TO: Create BMP Thumbnails with Centered Colored Circle in C# (Aspose.Imaging for .NET)
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
            // Define base, input and output directories
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files from the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.*");

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load source image
                using (Image srcImage = Image.Load(inputPath))
                {
                    // Define thumbnail size
                    int thumbWidth = 150;
                    int thumbHeight = 150;

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_thumb.bmp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create BMP options with a FileCreateSource
                    using (BmpOptions bmpOptions = new BmpOptions())
                    {
                        bmpOptions.BitsPerPixel = 24;
                        FileCreateSource source = new FileCreateSource(outputPath, false);
                        bmpOptions.Source = source;

                        // Create thumbnail canvas
                        using (Image thumbImage = Image.Create(bmpOptions, thumbWidth, thumbHeight))
                        {
                            // Initialize graphics
                            Graphics graphics = new Graphics(thumbImage);
                            graphics.Clear(Color.White);

                            // Draw scaled source image onto thumbnail
                            graphics.DrawImage(
                                (RasterImage)srcImage,
                                new Rectangle(0, 0, thumbWidth, thumbHeight),
                                new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                                GraphicsUnit.Pixel);

                            // Draw centered colored circle
                            int radius = Math.Min(thumbWidth, thumbHeight) / 4;
                            int centerX = thumbWidth / 2;
                            int centerY = thumbHeight / 2;
                            Rectangle circleRect = new Rectangle(
                                centerX - radius,
                                centerY - radius,
                                radius * 2,
                                radius * 2);
                            graphics.DrawEllipse(new Pen(Color.Red, 3), circleRect);

                            // Save the thumbnail (output path already bound via FileCreateSource)
                            thumbImage.Save();
                        }
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
 * 1. When you need to generate a batch of 150 × 150 BMP preview images for a gallery and highlight each with a colored circle overlay.
 * 2. When an application must automatically create thumbnail icons for user‑uploaded pictures and add a visual marker for branding or status.
 * 3. When a reporting tool requires small BMP snapshots of larger images with a centered ellipse to indicate focus areas.
 * 4. When a legacy system only accepts BMP files, and you must produce consistent thumbnails with a custom graphic element using Aspose.Imaging in C#.
 * 5. When you want to preprocess a folder of images for a game asset pipeline, adding a colored circle to each thumbnail for quick identification.
 */
