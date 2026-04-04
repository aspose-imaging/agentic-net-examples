using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input CSV path and output directory
        string csvPath = @"C:\temp\dimensions.csv";
        string outputFolder = @"C:\temp\output";

        // Validate input CSV existence
        if (!File.Exists(csvPath))
        {
            Console.Error.WriteLine($"File not found: {csvPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputFolder);

        // Read all lines from CSV
        string[] lines = File.ReadAllLines(csvPath);
        int index = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Expected CSV format: width,height[,filename]
            string[] parts = line.Split(',');
            if (parts.Length < 2)
                continue; // skip malformed lines

            if (!int.TryParse(parts[0].Trim(), out int width) ||
                !int.TryParse(parts[1].Trim(), out int height))
                continue; // skip lines with invalid numbers

            // Determine output file name
            string fileName = parts.Length >= 3 && !string.IsNullOrWhiteSpace(parts[2])
                ? parts[2].Trim()
                : $"image_{index}.bmp";

            string outputPath = Path.Combine(outputFolder, fileName);

            // Ensure directory for this output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create source bound to the output file
            Source source = new FileCreateSource(outputPath, false);

            // Set BMP options with the source
            BmpOptions bmpOptions = new BmpOptions() { Source = source };

            // Create a raster canvas with specified dimensions
            using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                // Optionally, fill the canvas with a default color (white)
                // canvas.SaveArgb32Pixels(canvas.Bounds, new Aspose.Imaging.Color[width * height]);

                // Save the bound image
                canvas.Save();
            }

            index++;
        }
    }
}