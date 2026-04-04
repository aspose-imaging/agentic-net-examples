using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input and output directories (hard‑coded)
        string inputDir = "Input";
        string outputDir = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDir);

        // Process each file in the input directory
        var inputFiles = Directory.GetFiles(inputDir);
        foreach (var inputPath in inputFiles)
        {
            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a thumbnail of fixed size (e.g., 100 × 100)
                int thumbWidth = 100;
                int thumbHeight = 100;
                image.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                // Draw a thin black border around the thumbnail
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(Color.Black, 1);
                Rectangle borderRect = new Rectangle(0, 0, image.Width - 1, image.Height - 1);
                graphics.DrawRectangle(pen, borderRect);

                // Build the output file path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the thumbnail as BMP
                image.Save(outputPath, new BmpOptions());
            }
        }
    }
}