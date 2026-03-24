using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.jpg";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // List of raster formats that Aspose.Imaging can load and convert to SVG
        List<string> rasterFormats = new List<string>
        {
            "JPEG",
            "PNG",
            "BMP",
            "GIF",
            "TIFF",
            "WebP",
            "DICOM",
            "Djvu",
            "CMX",
            "CDR"
        };

        Console.WriteLine("Supported raster image formats for conversion to SVG:");
        foreach (string format in rasterFormats)
        {
            Console.WriteLine("- " + format);
        }
    }
}