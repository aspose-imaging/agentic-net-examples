using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string csvPath = @"C:\Images\crop_data.csv";
        string inputFolder = @"C:\Images\Input\";
        string outputFolder = @"C:\Images\Output\";

        try
        {
            // Verify CSV file exists
            if (!File.Exists(csvPath))
            {
                Console.Error.WriteLine($"File not found: {csvPath}");
                return;
            }

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputFolder);

            // Read all lines from the CSV
            foreach (var line in File.ReadLines(csvPath))
            {
                // Skip empty lines and possible header
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("filename", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Expected format: filename,left,top,width,height
                var parts = line.Split(',');
                if (parts.Length < 5)
                    continue; // malformed line

                string fileName = parts[0].Trim();
                if (!int.TryParse(parts[1], out int left)) continue;
                if (!int.TryParse(parts[2], out int top)) continue;
                if (!int.TryParse(parts[3], out int width)) continue;
                if (!int.TryParse(parts[4], out int height)) continue;

                string inputPath = Path.Combine(inputFolder, fileName);

                // Input file existence check
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Define cropping rectangle
                    var cropArea = new Aspose.Imaging.Rectangle(left, top, width, height);

                    // Perform cropping
                    image.Crop(cropArea);

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(fileName) + "_cropped.jpg";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the cropped image as JPEG
                    var jpegOptions = new JpegOptions();
                    image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to batch‑crop product JPEG photos for an e‑commerce catalog by reading left, top, width, and height values from a CSV file and saving the cropped images to an output folder.
 * 2. When an automated pipeline must extract individual frames from scanned JPEG pages of a comic book using rectangle coordinates stored in a CSV and write the cropped results to a directory.
 * 3. When a content‑management system has to generate thumbnail JPEGs for user‑uploaded images based on cropping data supplied by a design tool in CSV format and place them in a designated output location.
 * 4. When a digital‑archiving project requires trimming white margins from thousands of JPEG scans according to pre‑calculated rectangle coordinates exported to a CSV file and outputting the cleaned images to a separate folder.
 * 5. When a marketing automation script needs to create region‑specific banner JPEGs by cropping source images using coordinates read from a CSV and storing the cropped versions in an output directory.
 */