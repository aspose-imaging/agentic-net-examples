using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input/Output directory setup
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Enumerate all files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*");
        foreach (string inputPath in files)
        {
            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileName = Path.GetFileNameWithoutExtension(inputPath);
            string extension = Path.GetExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, $"{fileName}_processed{extension}");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image and apply transformations
            using (Image image = Image.Load(inputPath))
            {
                if (image is RasterImage raster)
                {
                    // Crop 10 pixels from each side (if possible)
                    int leftShift = 10, rightShift = 10, topShift = 10, bottomShift = 10;
                    int croppedWidth = Math.Max(raster.Width - leftShift - rightShift, 1);
                    int croppedHeight = Math.Max(raster.Height - topShift - bottomShift, 1);
                    raster.Crop(leftShift, rightShift, topShift, bottomShift);

                    // Rotate 90 degrees clockwise, expanding canvas and filling background with white
                    raster.Rotate(90f, true, Color.White);

                    // Resize to half of the cropped dimensions
                    raster.Resize(croppedWidth / 2, croppedHeight / 2);

                    // Save processed image
                    raster.Save(outputPath);
                }
                else
                {
                    // For non‑raster images, simply copy to output
                    image.Save(outputPath);
                }
            }
        }
    }
}