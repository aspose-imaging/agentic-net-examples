using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output locations
        string inputPath = @"C:\temp\multipage.tif";
        string outputDirectory = @"C:\temp\output";

        try
        {
            // Verify the source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF
            using (TiffImage multiPage = (TiffImage)Image.Load(inputPath))
            {
                TiffFrame[] frames = multiPage.Frames;

                for (int i = 0; i < frames.Length; i++)
                {
                    // Clone the current frame to avoid disposing the original one
                    TiffFrame clonedFrame = new TiffFrame((RasterImage)frames[i]);

                    // Create a new TiffImage containing only this frame
                    using (TiffImage singlePage = new TiffImage(clonedFrame))
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF, preserving its metadata
                        singlePage.Save(outputPath);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}