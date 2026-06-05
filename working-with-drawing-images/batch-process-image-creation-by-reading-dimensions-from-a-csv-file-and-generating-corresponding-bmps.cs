using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string csvPath = @"C:\temp\dimensions.csv";
        string outputDir = @"C:\temp\output\";

        try
        {
            // Verify input CSV exists
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            // Read all lines from CSV
            string[] lines = File.ReadAllLines(csvPath);
            int index = 0;

            foreach (string line in lines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Expected format: width,height
                string[] parts = line.Split(',');
                if (parts.Length < 2)
                {
                    Console.Error.WriteLine($"Invalid line format at index {index}: {line}");
                    continue;
                }

                if (!int.TryParse(parts[0].Trim(), out int width) || !int.TryParse(parts[1].Trim(), out int height))
                {
                    Console.Error.WriteLine($"Invalid dimensions at index {index}: {line}");
                    continue;
                }

                // Build output file path
                string outputPath = Path.Combine(outputDir, $"image_{index}.bmp");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Set up BMP options with a file create source
                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 24,
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create a new image with the specified dimensions
                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    // Save the image (the source is already set to the output file)
                    image.Save();
                }

                index++;
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
 * 1. When a developer needs to generate a set of placeholder BMP files for UI mock‑ups based on size specifications stored in a CSV inventory.
 * 2. When an automated testing framework must create images of exact pixel dimensions to validate scaling algorithms in a C# application.
 * 3. When a game asset pipeline requires bulk creation of texture maps in BMP format using dimension data exported from a spreadsheet.
 * 4. When a reporting tool has to produce thumbnail‑size BMP charts for each record listed in a CSV file of width and height values.
 * 5. When a legacy system expects BMP files of predefined sizes, and a developer automates their production by reading the required dimensions from a CSV configuration file.
 */