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
        string inputFolder = "Input";
        string outputFolder = "Output";

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Get all files in the input folder
        string[] inputFiles = Directory.GetFiles(inputFolder);
        foreach (string inputPath in inputFiles)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + "_thumb.bmp");

            // Ensure output directory exists (unconditional)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Thumbnail dimensions
            int thumbWidth = 100;
            int thumbHeight = 100;

            // Load source image as RasterImage
            using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
            {
                // Create BMP options with bound output file
                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                // Create thumbnail canvas
                using (Image thumbImage = Image.Create(bmpOptions, thumbWidth, thumbHeight))
                {
                    // Initialize graphics for drawing
                    Graphics graphics = new Graphics(thumbImage);

                    // Draw the source image scaled to thumbnail size
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, thumbWidth, thumbHeight));

                    // Define centered circle parameters
                    int radius = Math.Min(thumbWidth, thumbHeight) / 2 - 5;
                    int centerX = thumbWidth / 2;
                    int centerY = thumbHeight / 2;
                    Rectangle circleRect = new Rectangle(centerX - radius, centerY - radius, radius * 2, radius * 2);

                    // Draw the circle using a red pen
                    Pen pen = new Pen(Color.Red, 3);
                    graphics.DrawEllipse(pen, circleRect);

                    // Save the thumbnail (output file already bound)
                    thumbImage.Save();
                }
            }
        }
    }
}