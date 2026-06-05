using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.dcm";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Load DICOM data into a byte array
            byte[] dicomData = File.ReadAllBytes(inputPath);

            // Use MemoryStream for in‑memory processing
            using (MemoryStream inputStream = new MemoryStream(dicomData))
            using (DicomImage dicomImage = new DicomImage(inputStream))
            {
                // Save the image as PNG
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
                {
                    // Save the whole image; bounds can be empty (default) to use full image
                    dicomImage.Save(outputStream, new PngOptions(), new Rectangle());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}