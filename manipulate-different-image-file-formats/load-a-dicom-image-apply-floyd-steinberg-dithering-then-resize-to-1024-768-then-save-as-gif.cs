using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output\\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            // Apply Floyd‑Steinberg dithering with a 1‑bit palette
            dicomImage.Dither(DitheringMethod.FloydSteinbergDithering, 1, null);

            // Resize to 1024×768 using nearest‑neighbour resampling
            dicomImage.Resize(1024, 768, ResizeType.NearestNeighbourResample);

            // Save the result as a GIF image
            GifOptions gifOptions = new GifOptions();
            dicomImage.Save(outputPath, gifOptions);
        }
    }
}