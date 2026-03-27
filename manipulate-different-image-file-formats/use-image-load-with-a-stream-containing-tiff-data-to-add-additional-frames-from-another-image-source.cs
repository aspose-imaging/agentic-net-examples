using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string tiffInputPath = "input\\source.tif";
        string pngInputPath = "input\\frame.png";
        string outputPath = "output\\result.tif";

        // Verify input files exist
        if (!File.Exists(tiffInputPath))
        {
            Console.Error.WriteLine($"File not found: {tiffInputPath}");
            return;
        }
        if (!File.Exists(pngInputPath))
        {
            Console.Error.WriteLine($"File not found: {pngInputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the existing TIFF image from a memory stream
        byte[] tiffBytes = File.ReadAllBytes(tiffInputPath);
        using (MemoryStream tiffStream = new MemoryStream(tiffBytes))
        {
            using (TiffImage tiffImage = (TiffImage)Image.Load(tiffStream))
            {
                // Load the additional frame image (PNG) from file
                using (Image pngImage = Image.Load(pngInputPath))
                {
                    // Create a TiffFrame from the raster image
                    TiffFrame newFrame = new TiffFrame((RasterImage)pngImage);
                    // Add the new frame to the TIFF image
                    tiffImage.AddFrame(newFrame);
                }

                // Save the updated TIFF image
                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffImage.Save(outputPath, saveOptions);
            }
        }
    }
}