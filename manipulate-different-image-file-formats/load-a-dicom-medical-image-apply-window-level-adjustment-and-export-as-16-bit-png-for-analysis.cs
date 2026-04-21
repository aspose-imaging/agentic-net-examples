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
            // Hard‑coded input and output file paths
            string inputPath = "input.dcm";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific operations
                DicomImage dicomImage = (DicomImage)image;

                // Apply window‑level adjustment (approximated with brightness and contrast)
                // Adjust these values as needed for the specific window level
                dicomImage.AdjustBrightness(40);      // Example brightness offset
                dicomImage.AdjustContrast(30f);       // Example contrast factor

                // Prepare PNG options for 16‑bit output
                var pngOptions = new PngOptions
                {
                    BitDepth = 16
                };

                // Save the processed image as a 16‑bit PNG
                dicomImage.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}