using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hardcoded input GIF file paths
        string[] inputPaths = new string[]
        {
            "input1.gif",
            "input2.gif",
            "input3.gif"
        };

        // Hardcoded output TIFF file path
        string outputPath = "output.tif";

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up TIFF creation options
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Load the first GIF and create the initial TIFF image
        using (RasterImage firstGif = (RasterImage)Image.Load(inputPaths[0]))
        using (TiffFrame firstFrame = new TiffFrame(firstGif))
        using (TiffImage tiffImage = new TiffImage(firstFrame))
        {
            // Add remaining GIFs as additional frames
            for (int i = 1; i < inputPaths.Length; i++)
            {
                using (RasterImage gif = (RasterImage)Image.Load(inputPaths[i]))
                {
                    TiffFrame frame = new TiffFrame(gif);
                    tiffImage.AddFrame(frame);
                    // Frame will be disposed automatically when the TiffImage is disposed
                }
            }

            // Save the multipage TIFF
            tiffImage.Save();
        }
    }
}