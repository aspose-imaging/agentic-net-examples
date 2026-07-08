using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            // Ensure input and output directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string extension = Path.GetExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{fileName}_processed{extension}");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Crop: remove 10 pixels from each side if possible
                    if (image.Width > 20 && image.Height > 20)
                    {
                        var cropRect = new Rectangle(10, 10, image.Width - 20, image.Height - 20);
                        image.Crop(cropRect);
                    }

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
 * 1. When a developer needs to automatically prepare a batch of product photos (e.g., JPEG or PNG) by trimming borders, rotating them to portrait orientation, and shrinking them for faster web loading.
 * 2. When an e‑commerce platform must process user‑uploaded images in a folder, applying a 10‑pixel crop, a 90‑degree clockwise rotate, and resizing to half size before storing them in a CDN.
 * 3. When a digital asset management system requires a nightly C# job that reads all images from an Input directory, normalizes their orientation, removes unwanted edges, and reduces dimensions to conserve storage.
 * 4. When a marketing team wants to generate thumbnail versions of a large collection of campaign graphics by cropping, rotating, and resizing them in a single Aspose.Imaging pipeline.
 * 5. When a mobile app backend needs to batch‑convert scanned documents (TIFF, BMP) into smaller, correctly oriented images for preview thumbnails using C# and Aspose.Imaging.
 */