using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all PNG files in the input folder
            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            // Path to the overlay image (must be a PNG with alpha channel)
            string overlayPath = "overlay.png";
            if (!File.Exists(overlayPath))
            {
                Console.Error.WriteLine($"File not found: {overlayPath}");
                return;
            }

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Determine output JPEG path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load base PNG image
                using (RasterImage baseImage = (RasterImage)Image.Load(inputPath))
                // Load overlay PNG image
                using (RasterImage overlayImage = (RasterImage)Image.Load(overlayPath))
                {
                    // Apply overlay with 64 (out of 255) opacity
                    baseImage.Blend(new Point(0, 0), overlayImage, 64);

                    // Prepare JPEG options with a file source
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };

                    // Save the result as JPEG
                    baseImage.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}