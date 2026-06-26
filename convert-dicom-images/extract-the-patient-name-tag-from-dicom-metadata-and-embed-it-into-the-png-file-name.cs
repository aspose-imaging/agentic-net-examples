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

            using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
            {
                string baseName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, $"{baseName}.png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                dicom.Save(outputPath, new PngOptions());
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
 * 1. When a hospital IT system needs to convert DICOM scans to PNG thumbnails and include the patient’s name from the DICOM metadata in the file name for easy identification in electronic health records.
 * 2. When a medical research application batch‑processes thousands of DICOM images, extracting the PatientName tag and appending it to each PNG filename to simplify data indexing and retrieval.
 * 3. When a radiology web portal displays patient images as PNGs, developers can use this code to embed the patient name from the DICOM header into the PNG filename so that URLs are self‑descriptive.
 * 4. When a mobile health app syncs imaging data, the code can convert DICOM files to PNG and rename them with the patient name, enabling users to locate their own images without opening each file.
 * 5. When a compliance audit requires that exported image files carry identifiable patient information, this C# routine extracts the DICOM PatientName tag and embeds it into the PNG filename for traceability.
 */