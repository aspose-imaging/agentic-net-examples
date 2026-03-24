using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputTiffPath = @"c:\temp\input.tif";
        string layerImagePath = @"c:\temp\layer.png";
        string outputTiffPath = @"c:\temp\output.tif";

        // Verify input files exist
        if (!File.Exists(inputTiffPath))
        {
            Console.Error.WriteLine($"File not found: {inputTiffPath}");
            return;
        }
        if (!File.Exists(layerImagePath))
        {
            Console.Error.WriteLine($"File not found: {layerImagePath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

        // Load the existing TIFF image
        using (TiffImage tiffImage = (TiffImage)Image.Load(inputTiffPath))
        {
            // Load the image to be added as a new layer/frame
            using (RasterImage layerImage = (RasterImage)Image.Load(layerImagePath))
            {
                // Create a new TIFF frame from the layer image
                TiffFrame newFrame = new TiffFrame(layerImage);

                // Add the new frame to the TIFF image
                tiffImage.AddFrame(newFrame);
            }

            // Save the modified TIFF to the output path
            tiffImage.Save(outputTiffPath);
        }
    }
}