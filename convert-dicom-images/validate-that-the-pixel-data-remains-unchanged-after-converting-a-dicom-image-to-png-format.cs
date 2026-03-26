using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        int[] originalPixels;

        // Load DICOM, extract pixel data, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            DicomImage dicom = (DicomImage)image;
            originalPixels = dicom.LoadArgb32Pixels(dicom.Bounds);
            dicom.Save(outputPath, new PngOptions());
        }

        // Load the saved PNG and extract its pixel data
        int[] pngPixels;
        using (Image pngImage = Image.Load(outputPath))
        {
            RasterImage raster = (RasterImage)pngImage;
            pngPixels = raster.LoadArgb32Pixels(raster.Bounds);
        }

        // Compare pixel arrays
        bool identical = originalPixels.Length == pngPixels.Length && originalPixels.SequenceEqual(pngPixels);
        Console.WriteLine(identical ? "Pixel data unchanged." : "Pixel data differs.");
    }
}