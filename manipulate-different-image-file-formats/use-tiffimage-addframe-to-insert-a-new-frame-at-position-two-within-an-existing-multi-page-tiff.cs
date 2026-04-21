using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing multi‑page TIFF
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Determine dimensions from the first frame (assumes all frames share size)
                int width = tiffImage.ActiveFrame.Width;
                int height = tiffImage.ActiveFrame.Height;

                // Create a new blank frame with default options
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(frameOptions, width, height);

                // Insert the new frame at position two (index 1, zero‑based)
                tiffImage.InsertFrame(1, newFrame);

                // Save the modified TIFF to the output path
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}