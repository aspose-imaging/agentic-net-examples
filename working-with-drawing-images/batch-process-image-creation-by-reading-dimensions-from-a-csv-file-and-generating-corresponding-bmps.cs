// HOW-TO: Generate Multiple BMP Images from CSV Dimensions Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace BatchImageCreator
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input CSV and output directory
                string inputCsvPath = "input.csv";
                string outputDirectory = "output";

                // Verify input CSV exists
                if (!File.Exists(inputCsvPath))
                {
                    Console.Error.WriteLine($"File not found: {inputCsvPath}");
                    return;
                }

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Read all lines from CSV
                string[] lines = File.ReadAllLines(inputCsvPath);
                foreach (string rawLine in lines)
                {
                    string line = rawLine.Trim();
                    if (string.IsNullOrEmpty(line))
                        continue; // skip empty lines

                    // Expect format: width,height
                    string[] parts = line.Split(',');
                    if (parts.Length != 2)
                    {
                        Console.Error.WriteLine($"Invalid line format (expected width,height): {line}");
                        continue;
                    }

                    if (!int.TryParse(parts[0].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int width) ||
                        !int.TryParse(parts[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int height))
                    {
                        Console.Error.WriteLine($"Invalid dimensions on line: {line}");
                        continue;
                    }

                    // Prepare output file path
                    string outputFileName = $"image_{width}x{height}.bmp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure directory for this output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create BMP image
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24
                    };

                    using (Image image = Image.Create(bmpOptions, width, height))
                    {
                        // Optionally fill with a solid color (white)
                        image.Save(outputPath);
                    }

                    Console.WriteLine($"Created: {outputPath}");
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
 * 1. When you need to create a set of placeholder BMP files with specific widths and heights listed in a CSV for testing UI layouts.
 * 2. When an automated pipeline must generate device‑specific splash screens from dimension data stored in a spreadsheet.
 * 3. When a reporting tool requires a batch of blank images sized to match chart dimensions defined in a CSV file.
 * 4. When a game developer wants to pre‑render texture atlases of exact pixel sizes based on a configuration list.
 * 5. When a legacy system expects BMP assets named by their dimensions and you must produce them programmatically from a CSV source.
 */
