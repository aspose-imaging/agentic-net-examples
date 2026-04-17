using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input DICOM file and output directory
        string inputPath = "input.dcm";
        string outputDirectory = "Output";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDirectory);

        // Log overall conversion start
        Console.WriteLine($"Conversion started at {DateTime.Now:O}");

        // Load DICOM image
        using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
        {
            int pageIndex = 0;
            foreach (var dicomPage in dicomImage.DicomPages)
            {
                // Log start of page conversion
                Console.WriteLine($"Page {pageIndex} conversion started at {DateTime.Now:O}");

                // Prepare output path for this page
                string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.png");

                // Ensure directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save page as PNG
                dicomPage.Save(outputPath, new PngOptions());

                // Log end of page conversion
                Console.WriteLine($"Page {pageIndex} conversion ended at {DateTime.Now:O}");

                pageIndex++;
            }
        }

        // Log overall conversion end
        Console.WriteLine($"Conversion completed at {DateTime.Now:O}");
    }
}