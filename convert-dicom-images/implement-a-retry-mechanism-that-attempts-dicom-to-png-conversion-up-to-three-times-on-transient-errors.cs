using System;
using System.IO;
using System.Linq;
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
            string outputPath = "Output/sample.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            const int maxAttempts = 3;
            for (int attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                    {
                        if (dicom.DicomPages.Count() > 1)
                        {
                            int pageIndex = 0;
                            foreach (var page in dicom.DicomPages)
                            {
                                string pageOutput = Path.Combine(
                                    Path.GetDirectoryName(outputPath),
                                    $"{Path.GetFileNameWithoutExtension(outputPath)}_{pageIndex}{Path.GetExtension(outputPath)}");

                                page.Save(pageOutput, new PngOptions());
                                pageIndex++;
                            }
                        }
                        else
                        {
                            dicom.Save(outputPath, new PngOptions());
                        }
                    }

                    break;
                }
                catch (Exception ex) when (attempt < maxAttempts)
                {
                    Console.Error.WriteLine($"Attempt {attempt} failed: {ex.Message}. Retrying...");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}