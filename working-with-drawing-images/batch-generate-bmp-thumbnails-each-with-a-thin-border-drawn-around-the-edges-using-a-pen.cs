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
            string inputDir = "Input";
            string outputDir = "Output";

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
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + "_thumb.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Determine thumbnail size (max 100x100 while preserving aspect ratio)
                    const int maxThumbWidth = 100;
                    const int maxThumbHeight = 100;
                    double ratio = Math.Min((double)maxThumbWidth / image.Width, (double)maxThumbHeight / image.Height);
                    int thumbWidth = (int)(image.Width * ratio);
                    int thumbHeight = (int)(image.Height * ratio);

                    // Resize to thumbnail dimensions
                    image.Resize(thumbWidth, thumbHeight);

                    // Draw a thin black border around the image
                    Graphics graphics = new Graphics(image);
                    Pen pen = new Pen(Color.Black, 1);
                    graphics.DrawRectangle(pen, 0, 0, image.Width - 1, image.Height - 1);

                    // Save as BMP
                    image.Save(outputPath, new BmpOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}