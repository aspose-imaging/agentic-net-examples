using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputTiffPath = "input.tif";
        string additionalImagePath = "additional.png";
        string outputTiffPath = "output.tif";

        // Input validation
        if (!File.Exists(inputTiffPath))
        {
            Console.Error.WriteLine($"File not found: {inputTiffPath}");
            return;
        }
        if (!File.Exists(additionalImagePath))
        {
            Console.Error.WriteLine($"File not found: {additionalImagePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

        try
        {
            // Load the existing TIFF image from a stream
            using (FileStream tiffStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Load the additional image (any supported format)
                using (Image extraImage = Image.Load(additionalImagePath))
                {
                    // Create a TiffFrame from the extra image
                    TiffFrame extraFrame = new TiffFrame((RasterImage)extraImage);

                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(extraFrame);
                }

                // Save the updated TIFF image
                tiffImage.Save(outputTiffPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}