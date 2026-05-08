using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputTiffPath = "input.tif";
        string additionalImagePath = "additional.png";
        string outputPath = "output.tif";

        // Verify input files exist
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

        try
        {
            // Load the base TIFF image from a stream
            using (FileStream tiffStream = new FileStream(inputTiffPath, FileMode.Open, FileAccess.Read))
            using (Image baseImage = Image.Load(tiffStream))
            {
                // Ensure the loaded image is a TIFF
                if (!(baseImage is TiffImage tiffImage))
                {
                    Console.Error.WriteLine("The input file is not a TIFF image.");
                    return;
                }

                // Load the additional image (e.g., PNG) to be added as a new frame
                using (Image addImage = Image.Load(additionalImagePath))
                {
                    // Create a TiffFrame from the additional raster image
                    TiffFrame newFrame = new TiffFrame((RasterImage)addImage);

                    // Add the new frame to the existing TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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