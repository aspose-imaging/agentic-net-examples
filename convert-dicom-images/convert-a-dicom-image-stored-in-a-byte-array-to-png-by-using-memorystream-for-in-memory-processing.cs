using System;
using System.IO;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (relative)
            string outputPath = Path.Combine("Output", "converted.png");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Example DICOM data in a byte array (replace with actual data)
            byte[] dicomData = new byte[0];

            // Load DICOM image from the byte array using a MemoryStream
            using (MemoryStream inputStream = new MemoryStream(dicomData))
            using (DicomImage dicomImage = new DicomImage(inputStream))
            using (MemoryStream outputStream = new MemoryStream())
            {
                // Set PNG save options
                PngOptions pngOptions = new PngOptions();

                // Save the DICOM image to the output stream as PNG
                dicomImage.Save(outputStream, pngOptions);

                // Write the PNG bytes to the output file
                File.WriteAllBytes(outputPath, outputStream.ToArray());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}