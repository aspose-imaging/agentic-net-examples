using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.dcm";
        string outputPath = "Output\\result.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image, apply dithering, resize, and save as GIF
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Apply Floyd‑Steinberg dithering with 8‑bit palette (null palette uses default)
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 8, null);

            // Resize to 1024x768 using nearest‑neighbour resampling
            dicomImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Save as GIF
            GifOptions gifOptions = new GifOptions();
            dicomImage.Save(outputPath, gifOptions);
        }
    }
}