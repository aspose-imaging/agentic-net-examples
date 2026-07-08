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
            // Hardcoded paths
            string csvPath = "input.csv";
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputImages";

            // Ensure output root exists
            Directory.CreateDirectory(outputDirectory);

            // Read CSV lines
            string[] lines = File.ReadAllLines(csvPath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Expected format: filename,x,y,width,height
                string[] parts = line.Split(',');
                if (parts.Length < 5)
                    continue;

                string fileName = parts[0].Trim();
                int x = int.Parse(parts[1].Trim());
                int y = int.Parse(parts[2].Trim());
                int width = int.Parse(parts[3].Trim());
                int height = int.Parse(parts[4].Trim());

                string inputPath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "_cropped" + Path.GetExtension(fileName);
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output subdirectory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    var cropArea = new Rectangle(x, y, width, height);
                    image.Crop(cropArea);
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
 * 1. When a developer needs to batch‑crop thousands of JPEG photos based on rectangle coordinates listed in a CSV file, such as extracting product thumbnails from a catalog.
 * 2. When an e‑commerce platform must automatically generate cropped preview images for uploaded product pictures using CSV‑defined crop areas.
 * 3. When a digital archiving system has to trim scanned JPEG document pages to remove margins by reading the crop rectangles from a CSV manifest.
 * 4. When a marketing team provides a list of banner sections to extract from high‑resolution JPEG assets, and a C# script must read the CSV coordinates and output the cropped pieces for social media.
 * 5. When a photo‑management application needs to process user‑defined crop areas stored in a CSV file to create uniformly sized JPEG thumbnails for a gallery view.
 */