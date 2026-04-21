using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output locations
        string inputPath = "input.tif";
        string outputDirectory = "output_frames";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑frame TIFF image
            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = image as TiffImage;
                if (tiffImage == null)
                {
                    Console.Error.WriteLine("The specified file is not a TIFF image.");
                    return;
                }

                // Iterate over each frame and save it as a separate TIFF file
                for (int i = 0; i < tiffImage.Frames.Length; i++)
                {
                    // Create a new TiffImage that contains only the current frame
                    using (TiffImage singleFrameImage = new TiffImage(tiffImage.Frames[i]))
                    {
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.tif");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the single‑frame TIFF
                        singleFrameImage.Save(outputPath);
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