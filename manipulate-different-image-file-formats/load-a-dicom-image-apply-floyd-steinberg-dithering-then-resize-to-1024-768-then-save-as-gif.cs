using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Apply Floyd‑Steinberg dithering with an 8‑bit palette
                dicomImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

                // Resize to 1024×768 using nearest‑neighbour resampling
                dicomImage.Resize(1024, 768, Aspose.Imaging.ResizeType.NearestNeighbourResample);

                // Save the result as a GIF image
                GifOptions gifOptions = new GifOptions();
                dicomImage.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}