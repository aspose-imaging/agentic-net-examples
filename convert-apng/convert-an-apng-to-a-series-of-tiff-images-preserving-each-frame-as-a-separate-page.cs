using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the APNG image
        using (Image loadedImage = Image.Load(inputPath))
        {
            ApngImage apngImage = loadedImage as ApngImage;
            if (apngImage == null)
            {
                Console.Error.WriteLine("The input file is not a valid APNG image.");
                return;
            }

            // Ensure there is at least one frame
            if (apngImage.PageCount == 0)
            {
                Console.Error.WriteLine("No frames found in the APNG image.");
                return;
            }

            // Create the first TIFF frame from the first APNG page
            TiffFrame firstTiffFrame = new TiffFrame((RasterImage)apngImage.Pages[0]);

            // Create a multi‑page TIFF image using the first frame
            using (TiffImage tiffImage = new TiffImage(firstTiffFrame))
            {
                // Add remaining frames as separate pages
                for (int i = 1; i < apngImage.PageCount; i++)
                {
                    TiffFrame tiffFrame = new TiffFrame((RasterImage)apngImage.Pages[i]);
                    tiffImage.AddFrame(tiffFrame);
                }

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the multi‑page TIFF
                tiffImage.Save(outputPath);
            }
        }
    }
}