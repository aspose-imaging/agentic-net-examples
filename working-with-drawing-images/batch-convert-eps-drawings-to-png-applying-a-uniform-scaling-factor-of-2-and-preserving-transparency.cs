using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = "InputEps";
        string outputFolder = "OutputPng";

        try
        {
            // Get all EPS files in the input folder
            string[] epsFiles = Directory.GetFiles(inputFolder, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PNG path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the EPS image
                using (Image image = Image.Load(inputPath))
                {
                    // Calculate new dimensions (scale factor of 2)
                    int newWidth = image.Width * 2;
                    int newHeight = image.Height * 2;

                    // Resize the image
                    image.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                    // Save as PNG preserving transparency
                    var pngOptions = new PngOptions();
                    image.Save(outputPath, pngOptions);
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
 * 1. When a graphic designer needs to convert a folder of vector EPS logos into high‑resolution PNG files for web use while doubling their size and keeping transparent backgrounds, this C# batch conversion code with Aspose.Imaging can automate the task.
 * 2. When a publishing workflow requires mass conversion of EPS illustrations to PNG thumbnails at twice the original dimensions for preview generation, developers can use this script to resize and preserve transparency in one pass.
 * 3. When an e‑learning platform must import a library of EPS diagrams and store them as scalable PNG assets for responsive HTML5 content, the code provides a fast C# solution to batch process and upscale the images.
 * 4. When a GIS application needs to transform EPS map overlays into PNG layers with a uniform scaling factor for overlay alignment, this Aspose.Imaging routine handles the conversion and maintains alpha channels.
 * 5. When a CI/CD pipeline has to automatically convert newly added EPS assets into double‑sized PNGs for mobile app assets while ensuring transparent backgrounds, the provided C# example performs the batch conversion reliably.
 */