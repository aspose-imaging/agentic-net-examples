// HOW-TO: Generate Multiple BMP Images from CSV Dimensions Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input CSV path
            string csvPath = @"C:\temp\dimensions.csv";

            // Verify input file exists
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            // Base directory for output BMP files
            string outputBaseDir = @"C:\temp\output";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBaseDir);

            using (var reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    // Expected CSV format: width,height,filename.bmp
                    string[] parts = line.Split(',');
                    if (parts.Length < 3)
                        continue; // skip malformed lines

                    int width = int.Parse(parts[0].Trim());
                    int height = int.Parse(parts[1].Trim());
                    string fileName = parts[2].Trim();

                    string outputPath = Path.Combine(outputBaseDir, fileName);

                    // Ensure directory for this output file exists
                    string outputDir = Path.GetDirectoryName(outputPath);
                    Directory.CreateDirectory(outputDir);

                    // Set up BMP options with a file create source
                    var bmpOptions = new BmpOptions
                    {
                        BitsPerPixel = 24,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    // Create a blank BMP image with the specified dimensions
                    using (Image image = Image.Create(bmpOptions, width, height))
                    {
                        // Save the image (the source is already set to the output file)
                        image.Save();
                    }
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
 * 1. When you need to automatically create placeholder BMP files for a large set of product images based on size data stored in a CSV file.
 * 2. When a game development pipeline requires generating terrain tiles of specific widths and heights defined in a spreadsheet.
 * 3. When a reporting system must produce blank bitmap canvases for later overlay of charts, using dimensions supplied by a data export.
 * 4. When a batch printing workflow needs pre‑sized BMP files for label templates whose dimensions are maintained in a CSV configuration.
 * 5. When an automated testing suite creates images of exact pixel dimensions to validate image‑processing algorithms.
 */
