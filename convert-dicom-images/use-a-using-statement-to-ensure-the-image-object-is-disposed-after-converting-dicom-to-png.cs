using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.dcm";
        string outputDirectory = "output";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Load the DICOM image and ensure it is disposed after use
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            int pageIndex = 0;
            foreach (DicomPage dicomPage in dicomImage.DicomPages)
            {
                // Build output file path for each page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                // Ensure the directory for the output file exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the page as PNG
                dicomPage.Save(outputPath, new PngOptions());

                pageIndex++;
            }
        }
    }
}