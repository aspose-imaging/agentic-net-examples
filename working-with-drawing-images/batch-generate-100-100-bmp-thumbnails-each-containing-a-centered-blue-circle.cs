// HOW-TO: Create 100x100 BMP Thumbnails With Centered Blue Circle In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = "InputImages";
            string outputDir = "Thumbnails";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Enumerate all files in the input directory
            string[] files = Directory.GetFiles(inputDir);
            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the source image as a raster image
                using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
                {
                    // Resize to 100 × 100 pixels
                    srcImage.Resize(100, 100);

                    // Draw a centered blue circle
                    Graphics graphics = new Graphics(srcImage);
                    int radius = 40; // circle radius
                    int centerX = srcImage.Width / 2;
                    int centerY = srcImage.Height / 2;
                    Rectangle circleRect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);
                    using (SolidBrush brush = new SolidBrush())
                    {
                        brush.Color = Color.Blue;
                        graphics.FillEllipse(brush, circleRect);
                    }

                    // Prepare output file path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDir, fileName + ".bmp");

                    // Ensure the output directory for this file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create BMP options bound to the output file
                    Source src = new FileCreateSource(outputPath, false);
                    BmpOptions bmpOptions = new BmpOptions() { Source = src, BitsPerPixel = 24 };

                    // Save the processed image as BMP
                    srcImage.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate small preview images for a photo gallery and highlight each preview with a blue marker.
 * 2. When you want to batch‑process a folder of pictures into uniform 100 × 100 BMP icons for a Windows application’s toolbar.
 * 3. When you have to create thumbnail assets for a game UI where each thumbnail must contain a blue circle indicating selection.
 * 4. When you need to prepare sample images for documentation that require a fixed size and a colored shape overlay.
 * 5. When you are building an automated pipeline that converts arbitrary source images into BMP thumbnails with a consistent visual cue for quality‑control reports.
 */
