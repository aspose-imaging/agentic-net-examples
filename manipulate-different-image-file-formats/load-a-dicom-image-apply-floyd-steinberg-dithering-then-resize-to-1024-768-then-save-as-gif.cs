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
        string inputPath = "input.dcm";
        string outputPath = "output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the DICOM image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DicomImage to access DICOM‑specific methods
                DicomImage dicomImage = (DicomImage)image;

                // Apply Floyd‑Steinberg dithering (8‑bit palette)
                dicomImage.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8, null);

                // Resize to 1024×768
                dicomImage.Resize(1024, 768);

                // Save as GIF
                dicomImage.Save(outputPath, new GifOptions());
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
 * 1. When a hospital’s PACS system needs to generate low‑size GIF thumbnails of DICOM scans for quick web preview, a developer can load the DICOM image, apply Floyd‑Steinberg dithering, resize to 1024×768, and save as GIF using Aspose.Imaging for .NET.
 * 2. When a telemedicine application must convert high‑resolution DICOM X‑ray images into 8‑bit GIFs that preserve visual detail while reducing bandwidth, the code can be used to dither, resize, and export the image in C#.
 * 3. When a research portal wants to display patient MRI slices in a browser‑friendly format, a developer can employ this snippet to transform DICOM files into 1024×768 GIFs with Floyd‑Steinberg dithering for better contrast.
 * 4. When an electronic health record (EHR) integration needs to embed diagnostic images as animated GIFs for mobile devices, the code provides a C# solution to load, dither, resize, and save the DICOM content.
 * 5. When a medical imaging workflow requires batch processing of DICOM files into standardized GIF assets for reporting tools, this Aspose.Imaging example shows how to automate the conversion, dithering, and resizing steps in .NET.
 */