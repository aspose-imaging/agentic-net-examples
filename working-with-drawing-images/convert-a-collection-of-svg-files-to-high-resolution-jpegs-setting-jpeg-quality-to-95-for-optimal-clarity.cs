using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    // Set up rasterization options for SVG
                    var rasterOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageSize = image.Size
                    };

                    // Configure JPEG options with high quality and resolution
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 95,
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        VectorRasterizationOptions = rasterOptions
                    };

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
 * 1. When a developer needs to batch‑convert a library of vector SVG logos into high‑resolution JPEGs with 95 % quality for use in print‑ready marketing materials.
 * 2. When an e‑commerce platform must generate product preview images from SVG designs as JPEG thumbnails that retain sharpness on high‑DPI screens.
 * 3. When a reporting tool built in C# requires rasterizing SVG charts into JPEG charts for inclusion in PDF reports that demand consistent image quality.
 * 4. When a legacy content management system only accepts JPEG files, a developer can use this code to automatically transform newly uploaded SVG assets into high‑quality JPEGs before publishing.
 * 5. When a mobile app needs to preload scalable SVG icons as JPEGs to reduce rendering overhead, this batch conversion ensures the images are optimized at 95 % JPEG quality for fast loading.
 */