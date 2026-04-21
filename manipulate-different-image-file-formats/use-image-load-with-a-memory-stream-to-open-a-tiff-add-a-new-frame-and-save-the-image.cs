using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (var memoryStream = new MemoryStream(fileBytes))
            using (Image image = Image.Load(memoryStream))
            {
                // Ensure the loaded image is a TIFF
                if (!(image is TiffImage tiffImage))
                {
                    Console.Error.WriteLine("The input file is not a TIFF image.");
                    return;
                }

                // Create a new blank frame (100x100) with default options
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                TiffFrame newFrame = new TiffFrame(frameOptions, 100, 100);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

                // Save the modified TIFF image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}