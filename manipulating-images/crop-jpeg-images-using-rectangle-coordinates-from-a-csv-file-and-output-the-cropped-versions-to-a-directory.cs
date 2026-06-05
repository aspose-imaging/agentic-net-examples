using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "Input";
            string outputDirectory = "Output";
            string csvPath = "crop_data.csv";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Read CSV lines
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            var lines = File.ReadAllLines(csvPath);
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Expected CSV format: filename,x,y,width,height
                var parts = line.Split(',');
                if (parts.Length < 5)
                    continue; // Skip malformed lines

                string fileName = parts[0].Trim();
                int x = int.Parse(parts[1].Trim());
                int y = int.Parse(parts[2].Trim());
                int width = int.Parse(parts[3].Trim());
                int height = int.Parse(parts[4].Trim());

                string inputPath = Path.Combine(inputDirectory, fileName);
                string outputPath = Path.Combine(outputDirectory, fileName);

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Ensure output subdirectory exists
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load, crop, and save
                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    Rectangle cropRect = new Rectangle(x, y, width, height);
                    raster.Crop(cropRect);
                    raster.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}