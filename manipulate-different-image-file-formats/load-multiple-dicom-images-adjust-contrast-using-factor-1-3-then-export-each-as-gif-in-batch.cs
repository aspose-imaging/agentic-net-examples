using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string[] inputPaths = {
            @"C:\Images\dicom1.dcm",
            @"C:\Images\dicom2.dcm",
            @"C:\Images\dicom3.dcm"
        };

        string[] outputPaths = {
            @"C:\Images\Output\dicom1.gif",
            @"C:\Images\Output\dicom2.gif",
            @"C:\Images\Output\dicom3.gif"
        };

        // Process each file in batch
        for (int i = 0; i < inputPaths.Length; i++)
        {
            string inputPath = inputPaths[i];
            string outputPath = outputPaths[i];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access AdjustContrast
                DicomImage dicomImage = (DicomImage)image;

                // Adjust contrast (value 30 corresponds to ~1.3 factor)
                dicomImage.AdjustContrast(30f);

                // Save as GIF
                var gifOptions = new GifOptions();
                dicomImage.Save(outputPath, gifOptions);
            }
        }
    }
}