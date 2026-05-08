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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load TIFF image from a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream inputStream = new MemoryStream(fileBytes))
            {
                using (TiffImage tiffImage = (TiffImage)Image.Load(inputStream))
                {
                    // Create a new blank frame with same dimensions as the existing image
                    TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                    TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);

                    // Save the modified TIFF image
                    tiffImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}