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
        string inputPath = "Input/sample.dcm";
        string outputPath = "Output/sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image
        using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
        {
            // Check DICOM file integrity
            if (!dicom.IsValid)
            {
                Console.Error.WriteLine($"Invalid DICOM file: {inputPath}");
                return;
            }

            // Convert each DICOM page to PNG
            foreach (var page in dicom.DicomPages)
            {
                string pageOutput = outputPath;

                // If multiple pages, create distinct file names
                if (dicom.DicomPages.Count > 1)
                {
                    string dir = Path.GetDirectoryName(outputPath);
                    string name = Path.GetFileNameWithoutExtension(outputPath);
                    string ext = Path.GetExtension(outputPath);
                    pageOutput = Path.Combine(dir, $"{name}_page{page.Index}{ext}");
                    Directory.CreateDirectory(Path.GetDirectoryName(pageOutput));
                }

                // Save page as PNG
                page.Save(pageOutput, new PngOptions());
            }
        }
    }
}