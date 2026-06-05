using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input, output and configuration file paths
            string inputPath = @"C:\Images\sample.cmx";
            string outputPath = @"C:\Images\output.jpg";
            string configPath = @"C:\Images\jpeg_quality.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Verify configuration file exists (optional)
            int jpegQuality = 90; // default quality
            if (File.Exists(configPath))
            {
                string txt = File.ReadAllText(configPath);
                if (int.TryParse(txt.Trim(), out int q) && q >= 1 && q <= 100)
                {
                    jpegQuality = q;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CMX image using CMX load options
            using (Image image = Image.Load(inputPath, new CmxLoadOptions()))
            {
                // Prepare JPEG save options with the desired quality
                JpegOptions saveOptions = new JpegOptions
                {
                    Quality = jpegQuality
                };

                // Save the image as JPEG
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}