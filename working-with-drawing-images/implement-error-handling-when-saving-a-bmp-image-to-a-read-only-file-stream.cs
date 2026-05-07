using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.CoreExceptions;
using Aspose.Imaging.CoreExceptions.ImageFormats;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Images\sample.bmp";
            string outputPath = @"C:\Images\readonly_output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the output file and mark it read‑only
            if (!File.Exists(outputPath))
            {
                using (var temp = new FileStream(outputPath, FileMode.Create, FileAccess.Write)) { }
            }
            File.SetAttributes(outputPath, FileAttributes.ReadOnly);

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Optional BMP save options
                BmpOptions saveOptions = new BmpOptions();

                // Open the target file as read‑only
                using (FileStream roStream = new FileStream(outputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    try
                    {
                        // Attempt to save to the read‑only stream
                        image.Save(roStream, saveOptions);
                        Console.WriteLine("Image saved successfully.");
                    }
                    catch (ImageSaveException ex)
                    {
                        Console.Error.WriteLine($"ImageSaveException: {ex.Message}");
                    }
                    catch (BmpImageException ex)
                    {
                        Console.Error.WriteLine($"BmpImageException: {ex.Message}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}