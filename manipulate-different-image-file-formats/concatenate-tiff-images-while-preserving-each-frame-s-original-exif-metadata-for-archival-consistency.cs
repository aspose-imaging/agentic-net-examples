using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.tif";
        string inputPath2 = "input2.tif";
        string outputPath = "output.tif";

        // Verify input files exist
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load source TIFF images
        using (TiffImage src1 = (TiffImage)Image.Load(inputPath1))
        using (TiffImage src2 = (TiffImage)Image.Load(inputPath2))
        // Create destination TIFF with frames from the first image
        using (TiffImage dest = new TiffImage(src1.Frames))
        {
            // Add frames from the second image, preserving EXIF metadata
            dest.Add(src2);

            // Save concatenated TIFF
            dest.Save(outputPath);
        }
    }
}