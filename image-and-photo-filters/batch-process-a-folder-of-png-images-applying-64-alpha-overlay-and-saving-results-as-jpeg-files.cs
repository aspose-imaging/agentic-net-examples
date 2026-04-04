using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Set up base, input and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        // Ensure input directory exists; if not, create and exit
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all PNG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.png");

        // Path to the overlay image (must be present in the input folder)
        string overlayPath = Path.Combine(inputDirectory, "overlay.png");
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        // Load overlay image once
        using (RasterImage overlay = (RasterImage)Image.Load(overlayPath))
        {
            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the background PNG image
                using (RasterImage background = (RasterImage)Image.Load(inputPath))
                {
                    // Apply the overlay with 64 (out of 255) alpha
                    background.Blend(new Point(0, 0), overlay, 64);

                    // Set JPEG save options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        Quality = 90
                    };

                    // Save the result as JPEG
                    background.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}