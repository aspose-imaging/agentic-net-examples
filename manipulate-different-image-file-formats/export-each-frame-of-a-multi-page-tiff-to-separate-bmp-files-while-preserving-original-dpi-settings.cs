using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputDir = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Load the multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Preserve original DPI
                double dpiX = tiffImage.HorizontalResolution;
                double dpiY = tiffImage.VerticalResolution;

                // Iterate through each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Set the current frame as active
                    tiffImage.ActiveFrame = tiffImage.Frames[i];

                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure BMP save options with original DPI
                    BmpOptions bmpOptions = new BmpOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ResolutionSettings = new ResolutionSetting(dpiX, dpiY)
                    };

                    // Save only the active frame as BMP
                    tiffImage.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}