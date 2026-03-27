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
        // Hardcoded input BMP file paths
        string[] inputPaths = {
            @"C:\temp\image1.bmp",
            @"C:\temp\image2.bmp",
            @"C:\temp\image3.bmp"
        };

        // Hardcoded output TIFF file path
        string outputPath = @"C:\temp\output.tif";

        // Validate each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load each BMP and create a corresponding TiffFrame
        TiffFrame[] frames = new TiffFrame[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            using (Image bmp = Image.Load(inputPaths[i]))
            {
                // BMP is a raster image; create a frame from it
                frames[i] = new TiffFrame((RasterImage)bmp);
            }
        }

        // Create a multi‑page TIFF from the frames and save it
        using (TiffImage tiffImage = new TiffImage(frames))
        {
            tiffImage.Save(outputPath);
        }
    }
}