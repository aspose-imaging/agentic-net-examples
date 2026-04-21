using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = "Output";

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Verify input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.Error.WriteLine($"Input directory not found: {inputDirectory}");
            return;
        }

        // Get all files in the input directory
        string[] inputFiles = Directory.GetFiles(inputDirectory);

        foreach (string inputPath in inputFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Load the image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Define thumbnail size
                int thumbWidth = 100;
                int thumbHeight = 100;

                // Resize to thumbnail dimensions
                image.Resize(thumbWidth, thumbHeight);

                // Create Graphics instance for drawing
                Graphics graphics = new Graphics(image);

                // Calculate centered circle dimensions (leave a small margin)
                int diameter = Math.Min(thumbWidth, thumbHeight) - 10;
                int x = (thumbWidth - diameter) / 2;
                int y = (thumbHeight - diameter) / 2;

                // Draw the centered circle using a red pen
                Pen pen = new Pen(Color.Red, 2);
                graphics.DrawEllipse(pen, new Rectangle(x, y, diameter, diameter));

                // Prepare output file path (BMP with same base name)
                string fileName = Path.GetFileNameWithoutExtension(inputPath) + ".bmp";
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the thumbnail as BMP
                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
            }
        }
    }
}