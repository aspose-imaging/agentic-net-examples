using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directory paths
            string inputPath = @"C:\Images\multiframe.tif";
            string outputDir = @"C:\Images\Frames";

            // Verify input file exists
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
                // Iterate through each frame
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    TiffFrame frame = tiffImage.Frames[i];

                    // Build output file path for this frame
                    string outputPath = Path.Combine(outputDir, $"frame_{i + 1}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP while preserving DPI
                    BmpOptions bmpOptions = new BmpOptions();
                    // DPI values are already stored in the frame; they will be written to the BMP automatically
                    frame.Save(outputPath, bmpOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}