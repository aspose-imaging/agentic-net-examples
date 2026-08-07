using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded list of input image files to be processed.
            string[] inputFiles = new string[]
            {
                @"c:\temp\image1.jpg",
                @"c:\temp\image2.bmp"
                // Add more input paths as needed.
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists.
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the source image (any supported format).
                using (Image image = Image.Load(inputPath))
                {
                    // Determine the crop rectangle that removes a 5‑pixel border from each side.
                    int cropX = 5;
                    int cropY = 5;
                    int cropWidth = image.Width - 10;
                    int cropHeight = image.Height - 10;

                    // If the image is too small to be cropped, skip it.
                    if (cropWidth <= 0 || cropHeight <= 0)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        continue;
                    }

                    var cropBounds = new Rectangle(cropX, cropY, cropWidth, cropHeight);

                    // Prepare PNG save options (default options are sufficient here).
                    var pngOptions = new PngOptions();

                    // Build the output path: same folder, same name, .png extension.
                    string outputPath = Path.ChangeExtension(inputPath, ".png");

                    // Ensure the output directory exists.
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped region as a PNG file.
                    image.Save(outputPath, pngOptions, cropBounds);
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
 * 1. When a developer needs to batch convert a collection of JPEG or BMP photos to PNG while removing a 5‑pixel border from each side for consistent thumbnail generation.
 * 2. When an e‑commerce platform must automatically process product images, cropping out unwanted edges and saving them as lossless PNG files for web display.
 * 3. When a desktop application prepares scanned documents by trimming uniform margins and converting them to PNG to ensure compatibility with downstream OCR tools.
 * 4. When a content‑management system migrates legacy image assets, applying a fixed border crop and converting them to PNG to standardize file formats across the repository.
 * 5. When a photo‑editing workflow requires a quick C# script to batch crop and re‑encode images to PNG before uploading them to a cloud storage service.
 */