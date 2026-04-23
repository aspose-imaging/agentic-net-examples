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
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TIFF image from a memory stream
            using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(inputPath)))
            using (Image image = Image.Load(ms))
            {
                // Cast to TiffImage to access frame operations
                TiffImage tiffImage = (TiffImage)image;

                // Create options for the new frame (default format)
                TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                // Optionally set basic properties
                frameOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                frameOptions.Photometric = TiffPhotometrics.Rgb;

                // Create a new blank frame with the same dimensions as the existing image
                TiffFrame newFrame = new TiffFrame(frameOptions, tiffImage.Width, tiffImage.Height);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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