using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\input.tif";
        string outputPath = @"C:\Temp\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load TIFF from file using TiffFrame constructor
        TiffFrame frame = new TiffFrame(inputPath);
        using (TiffImage tiffImage = new TiffImage(frame))
        {
            // Save the loaded image to the output path
            tiffImage.Save(outputPath);
        }

        // Load TIFF from a stream
        using (FileStream stream = File.OpenRead(inputPath))
        {
            TiffFrame streamFrame = new TiffFrame(stream);
            using (TiffImage streamImage = new TiffImage(streamFrame))
            {
                string streamOutputPath = @"C:\Temp\output_from_stream.tif";
                Directory.CreateDirectory(Path.GetDirectoryName(streamOutputPath));
                streamImage.Save(streamOutputPath);
            }
        }
    }
}