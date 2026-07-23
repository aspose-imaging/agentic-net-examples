using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = "InputImages";
            string outputDir = "OutputImages";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDir);
            foreach (string file in files)
            {
                string inputPath = file;

                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string extension = Path.GetExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + "_processed" + extension);

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load, process, and save the image
                using (Image image = Image.Load(inputPath))
                {
                    // Crop 10% from each side
                    int cropX = image.Width / 10;
                    int cropY = image.Height / 10;
                    int cropWidth = image.Width - 2 * cropX;
                    int cropHeight = image.Height - 2 * cropY;
                    var cropRect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
                    image.Crop(cropRect);

                    // Rotate 90 degrees clockwise
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);

                    // Resize to half of the current dimensions
                    int newWidth = image.Width / 2;
                    int newHeight = image.Height / 2;
                    image.Resize(newWidth, newHeight);

                    // Save the processed image
                    image.Save(outputPath);
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
 * 1. When a developer needs to automatically prepare a large collection of product photos (e.g., JPEG or PNG) by cropping borders, rotating to a standard orientation, and resizing them for an e‑commerce catalog, they can use this Aspose.Imaging batch pipeline.
 * 2. When a content management system must ingest user‑uploaded images and enforce consistent dimensions and aspect ratios before storage, the code can process an entire input folder and output uniformly cropped, rotated, and resized files.
 * 3. When a digital asset workflow requires nightly conversion of scanned documents into web‑ready thumbnails, the developer can run this C# script to batch‑process the scan folder, applying a 10 % crop, a 90‑degree rotation, and a size reduction in one pass.
 * 4. When a mobile app backend needs to generate optimized profile pictures from a batch of raw uploads, the code provides a simple way to load each image, apply cropping, rotate to portrait, and resize to the required pixel dimensions using Aspose.Imaging.
 * 5. When a marketing team wants to bulk‑prepare banner images for multiple languages, a developer can point the script at the source directory and automatically produce processed versions with consistent cropping, rotation, and scaling for each locale.
 */