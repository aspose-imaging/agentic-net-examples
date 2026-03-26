using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input DICOM file and output directory
        string inputPath = @"c:\temp\sample.dicom";
        string outputDir = @"c:\temp\output";

        // Input path safety check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the base output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the DICOM image from a file stream
        using (Stream stream = File.OpenRead(inputPath))
        {
            using (DicomImage dicomImage = new DicomImage(stream))
            {
                // Iterate through each page in the DICOM image
                foreach (DicomPage dicomPage in dicomImage.DicomPages)
                {
                    // Build the output PNG file path for the current page
                    string outputPath = Path.Combine(outputDir, $"page_{dicomPage.Index}.png");

                    // Record start timestamp
                    DateTime start = DateTime.Now;
                    Console.WriteLine($"Start conversion: Input={inputPath}, Page={dicomPage.Index}, Output={outputPath}, Time={start:O}");

                    // Output path safety: ensure directory exists before saving
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the page as a PNG image
                    dicomPage.Save(outputPath, new PngOptions());

                    // Record end timestamp and duration
                    DateTime end = DateTime.Now;
                    Console.WriteLine($"End conversion: Input={inputPath}, Page={dicomPage.Index}, Output={outputPath}, Time={end:O}, Duration={(end - start).TotalSeconds}s");
                }
            }
        }
    }
}