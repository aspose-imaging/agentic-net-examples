using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input CSV file path
        string inputPath = "dimensions.csv";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Hardcoded output directory
        string outputDir = "output";

        // Read all lines from CSV
        string[] lines = File.ReadAllLines(inputPath);
        int index = 1;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Expect format: width,height
            string[] parts = line.Split(',');
            if (parts.Length < 2)
                continue;

            int width = int.Parse(parts[0].Trim());
            int height = int.Parse(parts[1].Trim());

            // Build output file path
            string outputPath = Path.Combine(outputDir, $"image_{index}.bmp");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BMP options with file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions()
            {
                Source = source,
                BitsPerPixel = 24
            };

            // Create canvas and save
            using (RasterImage canvas = (RasterImage)Image.Create(options, width, height))
            {
                canvas.Save();
            }

            index++;
        }
    }
}