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
            string inputPath = "Input/sample.dicom";
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DicomImage dicomImage = (DicomImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    dicomImage.Save(ms, new PngOptions());
                    byte[] pngBytes = ms.ToArray();

                    File.WriteAllBytes(outputPath, pngBytes);
                    Console.WriteLine($"PNG byte array length: {pngBytes.Length}");
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
 * 1. When a hospital web portal needs to display radiology images in browsers, a developer can call an ASP.NET Core API that converts DICOM files to PNG byte arrays for fast client‑side rendering.
 * 2. When a telemedicine mobile app uploads DICOM scans to a server, the backend can use this endpoint to transform the scans into PNG streams that can be cached or sent over low‑bandwidth connections.
 * 3. When a research data pipeline requires extracting visual thumbnails from DICOM datasets, a developer can invoke the API to get PNG byte arrays for indexing and preview generation.
 * 4. When an electronic health record (EHR) system integrates third‑party imaging viewers, the API can supply PNG byte arrays from DICOM files so the viewer can render images without needing a DICOM library on the client.
 * 5. When a machine‑learning service needs to feed pixel data from medical images into a model, the endpoint can convert DICOM to PNG byte arrays, allowing the service to read standard image formats for preprocessing.
 */