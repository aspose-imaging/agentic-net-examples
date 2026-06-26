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
        try
        {
            string inputPath = "Input/sample.dcm";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                DicomImage dicomImage = (DicomImage)image;

                foreach (var page in dicomImage.DicomPages)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{page.Index}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    page.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital’s PACS system needs to batch‑convert incoming DICOM scans to PNG thumbnails, a developer can call Image.IsValid to skip corrupted files before saving each page as a PNG.
 * 2. When a research lab automates the extraction of image data from thousands of DICOM files for machine‑learning preprocessing, using Image.IsValid ensures only intact files are loaded and converted to PNG format.
 * 3. When a telemedicine app receives patient imaging uploads and must verify file integrity before displaying them in a web viewer, Image.IsValid can be used to validate the DICOM file before converting each frame to PNG.
 * 4. When a medical device manufacturer integrates Aspose.Imaging into a C# workflow that archives DICOM images as lossless PNGs, checking Image.IsValid prevents runtime exceptions caused by incomplete or tampered DICOM files.
 * 5. When a cloud‑based image‑processing service processes user‑submitted DICOM files and needs to log and skip invalid files during PNG conversion, developers can rely on Image.IsValid to filter out bad inputs efficiently.
 */