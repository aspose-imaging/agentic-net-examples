using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dcm";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var dicomImage = (Aspose.Imaging.FileFormats.Dicom.DicomImage)image;
                dicomImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 1, null);

                var tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);
                dicomImage.Save(outputPath, tiffOptions);
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
 * 1. When a radiology software needs to convert high‑resolution DICOM scans into printable black‑and‑white TIFF files with Floyd‑Steinberg dithering to preserve detail on legacy printers.
 * 2. When a healthcare data pipeline must batch‑process DICOM images, apply error‑diffusion dithering for better visual contrast, and store the results as TIFF for integration with document management systems.
 * 3. When a research application in C# requires extracting DICOM images, reducing them to a 1‑bit palette using Floyd‑Steinberg dithering, and saving as TIFF to meet journal submission guidelines.
 * 4. When a medical imaging archive needs to generate TIFF thumbnails from DICOM files with dithering to ensure consistent appearance across web browsers and image viewers.
 * 5. When a .NET developer wants to automate the conversion of DICOM ultrasound frames into TIFF format with Floyd‑Steinberg dithering for use in electronic health record (EHR) attachments.
 */