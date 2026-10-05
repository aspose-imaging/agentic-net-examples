// HOW-TO: Batch Convert SVG Files to High-Resolution JPEGs with 95% Quality in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

namespace SvgToJpegConverter
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = @"C:\InputSvgs";
                string outputDirectory = @"C:\OutputJpegs";

                // Ensure output directory exists
                Directory.CreateDirectory(outputDirectory);

                // Get all SVG files in the input directory
                string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");

                foreach (string inputPath in svgFiles)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Determine output file path with .jpg extension
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load SVG image
                    using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
                    {
                        // Set JPEG options with high quality and resolution
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 95,
                            ResolutionSettings = new ResolutionSetting(300, 300)
                        };

                        // Save as JPEG
                        svgImage.Save(outputPath, jpegOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate print‑ready JPEG images from a folder of vector SVG logos for marketing materials.
 * 2. When an e‑commerce platform requires high‑resolution product photos, converting designer‑provided SVG assets to JPEGs with 300 dpi and 95% quality.
 * 3. When automating the preparation of SVG icons for mobile apps that only support raster JPEG images at a specific resolution.
 * 4. When migrating a legacy website’s SVG graphics to JPEG format to improve compatibility with older browsers while preserving visual fidelity.
 * 5. When creating a batch processing script that reads multiple SVG files from a directory and saves them as high‑quality JPEGs for archival or reporting purposes.
 */
