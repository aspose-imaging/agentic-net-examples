using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
            // Ensure CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            // Read all lines from the CSV (expected format: filename,left,top,width,height)
            string[] lines = File.ReadAllLines(csvPath);
            foreach (string line in lines)
            {
                // Skip empty lines
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                // Split CSV fields
                string[] parts = line.Split(',');
                if (parts.Length < 5)
                {
                    Console.Error.WriteLine($"Invalid CSV line: {line}");
                    continue;
                }

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
                    // Cast to RasterImage to access Crop method
                    RasterImage rasterImage = (RasterImage)image;

                    // Define cropping rectangle
                    Rectangle cropArea = new Rectangle(left, top, width, height);

                    // Perform cropping
                    rasterImage.Crop(cropArea);

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "_cropped.jpg";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image as JPEG
                    rasterImage.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}