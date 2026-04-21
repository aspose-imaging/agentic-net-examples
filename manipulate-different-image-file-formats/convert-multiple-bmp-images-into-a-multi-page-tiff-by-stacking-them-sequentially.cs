using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input BMP files
        string[] inputPaths = new[]
        {
            @"c:\temp\image1.bmp",
            @"c:\temp\image2.bmp",
            @"c:\temp\image3.bmp"
        };

        // Hard‑coded output multi‑page TIFF file
        string outputPath = @"c:\temp\output.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first BMP and create the initial TIFF image
        using (Image firstBmp = Image.Load(inputPaths[0]))
        {
            // Create a TIFF frame from the first BMP
            TiffFrame firstFrame = new TiffFrame((RasterImage)firstBmp);

            // Create a TIFF image containing the first frame
            using (TiffImage tiffImage = new TiffImage(firstFrame))
            {
                // Process remaining BMP files and add them as frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (Image bmp = Image.Load(inputPaths[i]))
                    {
                        TiffFrame frame = new TiffFrame((RasterImage)bmp);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the multi‑page TIFF to the specified path
                tiffImage.Save(outputPath);
            }
        }
    }
}