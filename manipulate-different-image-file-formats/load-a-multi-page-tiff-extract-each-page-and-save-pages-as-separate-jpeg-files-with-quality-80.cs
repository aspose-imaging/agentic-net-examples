using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("Input", "multipage.tif");
            string outputDirectory = "Output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Iterate through each frame (page)
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Build output file path for the current page
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.jpg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure JPEG options with quality 80
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 80
                    };

                    // Save the current frame as a JPEG file
                    tiffImage.Frames[i].Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}