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
            // Hard‑coded input and output locations
            string inputPath = @"C:\temp\input.tif";
            string outputDirectory = @"C:\temp\output";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the multi‑page TIFF
            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a TIFF image
                if (image is TiffImage tiffImage)
                {
                    // Iterate through each frame (page) in the TIFF
                    for (int i = 0; i < tiffImage.Frames.Length; i++)
                    {
                        // Build the output JPEG file path
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.jpg");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Configure JPEG options with quality 80
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 80
                        };

                        // Save the current frame as a JPEG file
                        tiffImage.Frames[i].Save(outputPath, jpegOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a TIFF image.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}