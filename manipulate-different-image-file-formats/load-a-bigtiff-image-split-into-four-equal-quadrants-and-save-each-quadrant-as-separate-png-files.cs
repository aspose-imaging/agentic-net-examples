using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\bigimage.tif";
            string outputPath1 = @"C:\Images\quadrant_1.png";
            string outputPath2 = @"C:\Images\quadrant_2.png";
            string outputPath3 = @"C:\Images\quadrant_3.png";
            string outputPath4 = @"C:\Images\quadrant_4.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the BigTIFF image
            using (Image image = Image.Load(inputPath))
            {
                int halfWidth = image.Width / 2;
                int halfHeight = image.Height / 2;

                // Define the four quadrants
                var rect1 = new Rectangle(0, 0, halfWidth, halfHeight);                     // Top‑Left
                var rect2 = new Rectangle(halfWidth, 0, halfWidth, halfHeight);            // Top‑Right
                var rect3 = new Rectangle(0, halfHeight, halfWidth, halfHeight);           // Bottom‑Left
                var rect4 = new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight);  // Bottom‑Right

                // Prepare PNG save options (default options are sufficient)
                var pngOptions = new PngOptions();

                // Helper to save a quadrant
                void SaveQuadrant(string outputPath, Rectangle bounds)
                {
                    // Ensure the output directory exists
                    string dir = Path.GetDirectoryName(outputPath) ?? ".";
                    Directory.CreateDirectory(dir);

                    // Save the specified rectangle to a PNG file
                    using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                    {
                        image.Save(outStream, pngOptions, bounds);
                    }
                }

                // Save each quadrant
                SaveQuadrant(outputPath1, rect1);
                SaveQuadrant(outputPath2, rect2);
                SaveQuadrant(outputPath3, rect3);
                SaveQuadrant(outputPath4, rect4);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}