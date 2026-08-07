using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "sample.dcm";
        string outputPath = "sample.png";

        try
        {
            // Verify that the input DICOM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the DICOM image and save it as PNG in a single API call
            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
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
 * 1. When a radiology software needs to display DICOM scans on a web page, a developer can use this code to convert the DICOM file to a PNG image for browser compatibility.
 * 2. When a healthcare data pipeline requires archiving diagnostic images as lossless PNG files for long‑term storage, the code enables a quick C# conversion from DICOM to PNG in a single API call.
 * 3. When a medical research application must generate thumbnail previews of DICOM studies for a gallery view, the developer can load the DICOM and save it as PNG using Aspose.Imaging.
 * 4. When an electronic health record (EHR) system needs to embed patient imaging into PDF reports, the code provides a simple way to transform the DICOM image into a PNG that can be inserted into the document.
 * 5. When a cross‑platform mobile app consumes imaging data and requires a universally supported format, a C# backend can use this snippet to convert incoming DICOM files to PNG before sending them to the client.
 */