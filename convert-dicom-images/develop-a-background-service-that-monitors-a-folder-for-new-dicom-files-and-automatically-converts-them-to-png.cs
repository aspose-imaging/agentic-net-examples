using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string watchFolder = "C:\\InputDicom";
        string outputFolder = "C:\\OutputPng";

        Directory.CreateDirectory(outputFolder);

        var watcher = new FileSystemWatcher(watchFolder, "*.dcm");
        watcher.Created += (sender, e) =>
        {
            string inputPath = e.FullPath;

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(inputPath) + ".png");

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PngOptions());
            }
        };
        watcher.IncludeSubdirectories = false;
        watcher.EnableRaisingEvents = true;

        Console.WriteLine("Monitoring folder for new DICOM files. Press Enter to exit.");
        Console.ReadLine();
    }
}