using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.jpg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure JPEG save options with a file source
        Source jpegSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = jpegSource,
            Quality = 90
        };

        // Load CMX image, set background color, and save as JPEG
        using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
        {
            cmx.BackgroundColor = Aspose.Imaging.Color.White;
            cmx.HasBackgroundColor = true;
            cmx.Save(outputPath, jpegOptions);
        }
    }
}