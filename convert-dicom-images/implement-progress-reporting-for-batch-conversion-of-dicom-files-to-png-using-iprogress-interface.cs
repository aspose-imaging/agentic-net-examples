using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dicom;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ProgressManagement;

class Program
{
    static void Main(string[] args)
    {
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        string[] files = Directory.GetFiles(inputDirectory, "*.dcm");

        foreach (string inputPath in files)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (DicomImage dicom = (DicomImage)Image.Load(
                inputPath,
                new LoadOptions
                {
                    ProgressEventHandler = info => Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
                }))
            {
                foreach (var page in dicom.DicomPages)
                {
                    string outputFileName = $"{Path.GetFileNameWithoutExtension(inputPath)}_page{page.Index}.png";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions
                    {
                        ProgressEventHandler = info => Console.WriteLine($"{info.EventType} : {info.Value}/{info.MaxValue}")
                    };

                    page.Save(outputPath, pngOptions);
                }
            }
        }
    }
}