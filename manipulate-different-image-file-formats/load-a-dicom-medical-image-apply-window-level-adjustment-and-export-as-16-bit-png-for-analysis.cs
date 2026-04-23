using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Temp\input.dcm";
            string outputPath = @"C:\Temp\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply window‑level adjustment (approximated with brightness/contrast)
                dicomImage.AdjustBrightness(50);      // example brightness value
                dicomImage.AdjustContrast(30f);       // example contrast value

                // Prepare PNG options for 16‑bit output
                var pngOptions = new PngOptions
                {
                    BitDepth = 16
                };

                // Save the adjusted image as a 16‑bit PNG
                dicomImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}