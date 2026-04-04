using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string csvPath = @"C:\Images\crop_coords.csv";
        string inputDir = @"C:\Images\Input\";
        string outputDir = @"C:\Images\Output\";

        // Verify CSV file exists
        if (!File.Exists(csvPath))
        {
            Console.Error.WriteLine($"File not found: {csvPath}");
            return;
        }

        // Read all lines from CSV
        string[] lines = File.ReadAllLines(csvPath);
        foreach (string line in lines)
        {
            // Skip empty lines
            if (string.IsNullOrWhiteSpace(line))
                continue;

            // Expected CSV format: filename,left,top,width,height
            string[] parts = line.Split(',');
            if (parts.Length != 5)
                continue; // malformed line, ignore

            string fileName = parts[0].Trim();
            if (!int.TryParse(parts[1].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int left) ||
                !int.TryParse(parts[2].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int top) ||
                !int.TryParse(parts[3].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int width) ||
                !int.TryParse(parts[4].Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int height))
            {
                continue; // invalid numeric values, ignore
            }

            string inputPath = Path.Combine(inputDir, fileName);
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Define cropping rectangle
                var rect = new Aspose.Imaging.Rectangle(left, top, width, height);
                image.Crop(rect);

                // Prepare output path
                string outputPath = Path.Combine(outputDir, fileName);
                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save as JPEG (preserve original extension if desired)
                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
    }
}