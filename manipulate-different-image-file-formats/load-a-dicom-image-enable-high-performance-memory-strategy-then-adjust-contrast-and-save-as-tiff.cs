using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DICOM image with high‑performance memory strategy
        using (FileStream stream = File.OpenRead(inputPath))
        {
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BufferSizeHint = 256 * 1024; // 256 KB buffer hint

            using (DicomImage dicomImage = new DicomImage(stream, loadOptions))
            {
                // Adjust contrast (value range: -100 to 100)
                dicomImage.AdjustContrast(50f);

                // Save as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
            }
        }
    }
}