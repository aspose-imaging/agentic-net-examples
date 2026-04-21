using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output directories
        string inputFolder = "InputImages";
        string outputFolder = "Thumbnails";

        // Validate input directory
        if (!Directory.Exists(inputFolder))
        {
            Directory.CreateDirectory(inputFolder);
            Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Get all files from the input directory
        string[] inputFiles = Directory.GetFiles(inputFolder);
        foreach (string inputPath in inputFiles)
        {
            // Check that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                continue;
            }

            // Prepare output path with .bmp extension
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + "_thumb.bmp");

            // Ensure the output directory exists (redundant but follows rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with bound file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions bmpOptions = new BmpOptions() { Source = source, BitsPerPixel = 24 };

            // Create a 100x100 BMP image bound to the output file
            using (Image image = Image.Create(bmpOptions, 100, 100))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Draw a centered blue filled circle
                int radius = 40;
                int centerX = 50;
                int centerY = 50;
                int left = centerX - radius;
                int top = centerY - radius;
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    graphics.FillEllipse(brush, new Rectangle(left, top, radius * 2, radius * 2));
                }

                // Save the bound image
                image.Save();
            }
        }
    }
}