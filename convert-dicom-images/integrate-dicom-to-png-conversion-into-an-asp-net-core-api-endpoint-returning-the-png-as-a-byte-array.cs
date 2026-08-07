using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.dcm";
            string outputPath = "Output/sample.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DICOM image and save as PNG
            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                dicomImage.Save(outputPath, new PngOptions());
            }

            // Read the generated PNG into a byte array
            byte[] pngBytes = File.ReadAllBytes(outputPath);
            Console.WriteLine($"PNG byte array length: {pngBytes.Length}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a hospital’s web portal needs to display radiology images stored as DICOM files directly in a browser, a developer can use this code to convert the DICOM to PNG and return the PNG byte array from an ASP.NET Core API.
 * 2. When a telemedicine mobile app requests patient imaging data via a REST service, the backend can employ this conversion to transform DICOM scans into lightweight PNG streams for fast download.
 * 3. When an electronic health record (EHR) system integrates third‑party imaging archives, developers can expose an endpoint that turns DICOM files into PNG byte arrays for embedding in PDF reports.
 * 4. When a machine‑learning pipeline consumes medical images over HTTP, the API can use this code to serve PNG byte arrays instead of raw DICOM to simplify preprocessing.
 * 5. When a research portal offers public access to anonymized imaging studies, the server can convert each DICOM study to PNG on‑the‑fly and stream the byte array to web clients without storing intermediate files.
 */