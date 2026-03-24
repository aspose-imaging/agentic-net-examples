using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input image paths
        string[] inputPaths = new string[]
        {
            @"c:\temp\input1.png",
            @"c:\temp\input2.png",
            @"c:\temp\input3.png"
        };

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Hardcoded output TIFF path
        string outputPath = @"c:\temp\multipage.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the first image and create the initial TIFF image
        using (RasterImage firstRaster = (RasterImage)Image.Load(inputPaths[0]))
        {
            // Create a TiffFrame from the first raster image
            TiffFrame firstFrame = new TiffFrame(firstRaster);

            // Initialize TiffImage with the first frame
            using (TiffImage tiffImage = new TiffImage(firstFrame))
            {
                // Load remaining images and add them as additional frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage raster = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        TiffFrame frame = new TiffFrame(raster);
                        tiffImage.AddFrame(frame);
                    }
                }

                // Save the multi‑frame TIFF to the specified output path
                tiffImage.Save(outputPath);
            }
        }
    }
}