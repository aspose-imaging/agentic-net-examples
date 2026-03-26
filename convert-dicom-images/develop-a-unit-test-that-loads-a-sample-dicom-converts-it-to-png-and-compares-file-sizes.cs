using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dcm";
        string outputPath = "sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load DICOM and convert to PNG
        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            dicom.Save(outputPath, new PngOptions());
        }

        // Compare file sizes
        long dicomSize = new FileInfo(inputPath).Length;
        long pngSize = new FileInfo(outputPath).Length;

        Console.WriteLine($"DICOM size: {dicomSize} bytes");
        Console.WriteLine($"PNG size: {pngSize} bytes");

        if (pngSize < dicomSize)
            Console.WriteLine("PNG is smaller than DICOM.");
        else if (pngSize > dicomSize)
            Console.WriteLine("PNG is larger than DICOM.");
        else
            Console.WriteLine("PNG size equals DICOM size.");
    }
}