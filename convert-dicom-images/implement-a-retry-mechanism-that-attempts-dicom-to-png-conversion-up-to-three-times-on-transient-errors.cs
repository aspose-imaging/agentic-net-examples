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
            string inputPath = "Input/sample.dcm";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            int maxAttempts = 3;
            int attempt = 0;
            bool succeeded = false;

            while (attempt < maxAttempts && !succeeded)
            {
                try
                {
                    using (DicomImage dicom = (DicomImage)Image.Load(inputPath))
                    {
                        int pageIndex = 0;
                        foreach (var page in dicom.DicomPages)
                        {
                            string pageOutputPath = Path.Combine(outputDirectory, $"sample_page{pageIndex}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(pageOutputPath));
                            page.Save(pageOutputPath, new PngOptions());
                            pageIndex++;
                        }
                    }

                    succeeded = true;
                }
                catch (Exception ex)
                {
                    attempt++;
                    if (attempt >= maxAttempts)
                    {
                        throw;
                    }
                    // Optionally log transient error and retry
                    Console.Error.WriteLine($"Transient error occurred (attempt {attempt}): {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}