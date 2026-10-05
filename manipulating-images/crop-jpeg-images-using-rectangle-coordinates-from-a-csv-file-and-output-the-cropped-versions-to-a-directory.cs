// HOW-TO: Crop JPEG Images From CSV Coordinates Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

namespace ImageCropper
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded paths
                string csvPath = "input.csv";
                string imagesFolder = "images";
                string outputFolder = "output";

                // Validate CSV file existence
                if (!File.Exists(csvPath))
                {
                    Console.Error.WriteLine($"File not found: {csvPath}");
                    return;
                }

                // Read all lines from CSV
                string[] lines = File.ReadAllLines(csvPath);
                if (lines.Length == 0)
                {
                    Console.Error.WriteLine("CSV file is empty.");
                    return;
                }

                // Process each line (skip header if present)
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    // Simple check for header (contains non-numeric in coordinate fields)
                    if (i == 0 && (line.Contains("ImageFileName") || line.Contains("X")))
                        continue;

                    string[] parts = line.Split(',');
                    if (parts.Length < 5)
                    {
                        Console.Error.WriteLine($"Invalid CSV line: {line}");
                        continue;
                    }

                    string imageFileName = parts[0].Trim();
                    if (!int.TryParse(parts[1].Trim(), out int x) ||
                        !int.TryParse(parts[2].Trim(), out int y) ||
                        !int.TryParse(parts[3].Trim(), out int width) ||
                        !int.TryParse(parts[4].Trim(), out int height))
                    {
                        Console.Error.WriteLine($"Invalid rectangle values in line: {line}");
                        continue;
                    }

                    string inputPath = Path.Combine(imagesFolder, imageFileName);
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputFolder, imageFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
                    {
                        if (!rasterImage.IsCached)
                        {
                            rasterImage.CacheData();
                        }

                        Aspose.Imaging.Rectangle rectangle = new Aspose.Imaging.Rectangle(x, y, width, height);
                        rasterImage.Crop(rectangle);
                        rasterImage.Save(outputPath);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically trim product photos based on coordinates stored in a spreadsheet for an e‑commerce catalog.
 * 2. When a batch of scanned receipts must be cropped to the relevant area using coordinates supplied by a data‑entry system.
 * 3. When a marketing team provides a CSV of banner dimensions and you must generate cropped JPEG assets for a website.
 * 4. When you are preprocessing images for a machine‑learning pipeline and the region of interest is defined in a CSV file.
 * 5. When you want to replace manual Photoshop cropping with a C# script that reads rectangle values from a CSV and saves the results to a folder.
 */
