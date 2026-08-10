// HOW-TO: Batch Crop JPEG Images from CSV Coordinates Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string csvPath = @"C:\Images\crop_data.csv";
        string inputDirectory = @"C:\Images\Input";
        string outputDirectory = @"C:\Images\Output";

        try
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(csvPath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue; // Skip empty lines

                // Expected CSV format: FileName, Left, Top, Width, Height
                string[] parts = line.Split(',');

                if (parts.Length < 5)
                    continue; // Skip malformed lines

                string fileName = parts[0].Trim();
                int left = int.Parse(parts[1].Trim());
                int top = int.Parse(parts[2].Trim());
                int width = int.Parse(parts[3].Trim());
                int height = int.Parse(parts[4].Trim());

                // Build full input path and verify existence
                string inputPath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image using Aspose.Imaging
                using (Image image = Image.Load(inputPath))
                {
                    // Crop the image using the rectangle from CSV
                    var cropArea = new Rectangle(left, top, width, height);
                    image.Crop(cropArea);

                    // Prepare output path and ensure directory exists
                    string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "_cropped.jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image as JPEG
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
 * 1. When you need to automatically trim product photos to a standard size based on rectangle coordinates stored in a CSV file.
 * 2. When you have a large collection of scanned documents and must extract specific regions for archival using batch processing in C#.
 * 3. When a marketing team provides a spreadsheet of crop areas for campaign images and you need to generate the cropped JPEGs programmatically.
 * 4. When you want to preprocess satellite imagery by cutting out areas of interest defined in a CSV before further analysis.
 * 5. When you are building a desktop utility that reads user‑specified crop rectangles from a CSV and saves the resulting JPEGs to a separate output folder.
 */
