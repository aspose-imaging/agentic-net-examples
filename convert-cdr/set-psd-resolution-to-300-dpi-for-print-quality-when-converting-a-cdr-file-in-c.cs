using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cdr";
        string outputPath = "output.psd";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                PsdOptions psdOptions = new PsdOptions();
                psdOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0);
                image.Save(outputPath, psdOptions);
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
 * 1. When a developer needs to generate a high‑resolution PSD file from a CorelDRAW (CDR) source for professional printing, they can set the resolution to 300 DPI using Aspose.Imaging in C#.
 * 2. When an e‑commerce platform must convert customer‑uploaded CDR logos into print‑ready PSD assets with exact 300 DPI resolution for catalog production, this code provides the required conversion.
 * 3. When a marketing automation script creates PSD mockups from CDR designs and must guarantee print quality, the developer uses the resolution setting to enforce 300 DPI before saving.
 * 4. When a desktop publishing workflow requires batch processing of CDR files into PSD format with consistent 300 DPI output for offset printing, the code demonstrates how to achieve that in C#.
 * 5. When a digital asset management system needs to store PSD versions of vector CDR artwork at print‑grade resolution, developers can employ this snippet to set the DPI to 300 during conversion.
 */