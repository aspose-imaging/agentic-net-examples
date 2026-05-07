using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input CSV containing width,height per line
            string csvPath = "dimensions.csv";
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);

            string[] lines = File.ReadAllLines(csvPath);
            int index = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');
                if (parts.Length < 2)
                    continue;

                if (!int.TryParse(parts[0].Trim(), out int width) ||
                    !int.TryParse(parts[1].Trim(), out int height))
                    continue;

                string outputPath = Path.Combine(outputDir, $"image_{index}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP options with bound source
                FileCreateSource src = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions
                {
                    Source = src,
                    BitsPerPixel = 24
                };

                // Create canvas
                using (Image canvas = Image.Create(options, width, height))
                {
                    // Fill canvas with white background
                    Graphics graphics = new Graphics((RasterImage)canvas);
                    SolidBrush brush = new SolidBrush(Color.White);
                    graphics.FillRectangle(brush, new Rectangle(0, 0, width, height));

                    // Save bound image
                    canvas.Save();
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