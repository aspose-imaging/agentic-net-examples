using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Ensure output folder exists
            Directory.CreateDirectory(outputFolder);

            // Get all BMP files in the input folder
            string[] bmpFiles = Directory.GetFiles(inputFolder, "*.bmp");

            foreach (string inputPath in bmpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load BMP image
                using (Image bmpImage = Image.Load(inputPath))
                {
                    // Determine crop rectangle (10-pixel border on each side)
                    int cropX = 10;
                    int cropY = 10;
                    int cropWidth = bmpImage.Width - 20;
                    int cropHeight = bmpImage.Height - 20;

                    // Ensure dimensions are valid
                    if (cropWidth <= 0 || cropHeight <= 0)
                    {
                        Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                        continue;
                    }

                    // Perform cropping
                    bmpImage.Crop(new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight));

                    // Prepare output path with PNG extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                    // Ensure output directory exists (already created above, but keep rule)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as PNG
                    var pngOptions = new PngOptions();
                    bmpImage.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to migrate a legacy collection of BMP screenshots to PNG for web delivery while removing a 10‑pixel border from each image.
 * 2. When an automated build pipeline must generate optimized PNG assets from a folder of BMP icons, applying a uniform crop to eliminate unwanted margins.
 * 3. When a desktop application processes scanned documents stored as BMP files, trimming the edges and converting them to PNG for smaller file size and better compatibility.
 * 4. When a game studio wants to batch‑convert BMP texture atlases to PNG format and automatically crop a 10‑pixel padding around each texture to align with the engine’s requirements.
 * 5. When a reporting tool prepares a batch of BMP charts for inclusion in PDF reports, cropping the border and converting them to PNG to ensure lossless rendering and consistent image dimensions.
 */